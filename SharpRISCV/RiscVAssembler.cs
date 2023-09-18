﻿using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpRISCV
{
    class RiscVAssembler
    {
        private static List<RiscVInstruction> instruction = new List<RiscVInstruction>();

        public static List<RiscVInstruction> Instruction { get { return instruction; } }

        public static Dictionary<string, List<string>> DirectiveCode = new Dictionary<string, List<string>>();
        public static List<string> DataDirective = new List<string>();

        private static List<string> sectionsDirective = new List<string>()
        {
            ".data",".text"
        };

        private static string currentDirective = "";

        public static void Assamble(string code)
        {
            code = RemoveComments(code);
            code = TrimLines(code);
            BuildDirective(code);

            //Process .Text Lables
            foreach (var directive in DirectiveCode[".text"])
            {
                var lines = directive.SplitStingByNewLine();
                ProcessLables(lines);
            }

            //Process .Data Lables
            foreach (var directive in DirectiveCode[".data"])
            {
                var lines = directive.SplitStingByNewLine();
                ProcessLables(lines);
            }

            Address.Reset();

            //Process .Text Instructions
            foreach (var directive in DirectiveCode[".text"])
            {
                var lines = directive.SplitStingByNewLine();
                foreach (var line in lines)
                {
                    var instructionType = IdentifyInstructionType(line);
                    if (instructionType == InstructionType.EmptyLine) continue;
                    var riscVInstruction = InstructionParser(line.Trim(), instructionType);
                    instruction.Add(riscVInstruction);
                }
            }
        }

        private static RiscVInstruction DirectiveParser(string v)
        {
            if (v.EndsWith(":"))
                return (new Lable_Parser()).Parse(v);

            string directive = v.Substring(0, v.IndexOf(' ')).Trim();

            switch (directive)
            {
                case ".string":
                case ".asciz":
                    return null;
                default:
                    return null;
            }
        }

        public static List<MachineCode.MachineCode> MachineCode()
        {
            List<MachineCode.MachineCode> mc = new List<MachineCode.MachineCode>();

            foreach (var instruction in Instruction)
            {
                mc.AddRange(instruction.MachineCode());
            }

            return mc;
        }
        static void BuildDirective(string code)
        {
            string[] lines = code.SplitStingByNewLine();


            StringBuilder directiveCode = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.StartsWith(".") && sectionsDirective.Any(x => x == line.ToLower()))
                {
                    AddToRespativeDirective(directiveCode.ToString());
                    directiveCode.Clear();
                    currentDirective = line.ToLower();
                    continue;
                }

                directiveCode.AppendLine(line);
            }

            if (directiveCode.Length > 0)
                    AddToRespativeDirective(directiveCode.ToString());
        }

        static void AddToRespativeDirective(string directiveCode)
        {
            if (!string.IsNullOrEmpty(currentDirective))
            {
                if (DirectiveCode.ContainsKey(currentDirective))
                    DirectiveCode[currentDirective].Add(directiveCode.ToString());
                else
                    DirectiveCode[currentDirective] = new List<string> { directiveCode.ToString() };
            }
        }

        static string RemoveComments(string lines)
        {
            // Regular expression to match comments starting with '#' and everything after
            string pattern = @"#.*$";
            lines = Regex.Replace(lines, pattern, string.Empty, RegexOptions.Multiline);
            return lines;
        }

        static string TrimLines(string lines)
        {
            string pattern = @"^\s+|\s+$";
            lines = Regex.Replace(lines, pattern, string.Empty, RegexOptions.Multiline);
            return lines;
        }

        public static void ProcessLables(string[] code)
        {
            foreach (var assemblyLine in code)
            {
                if(string.IsNullOrEmpty(assemblyLine.Trim())) continue;
                if(assemblyLine.Trim().StartsWith(".")) continue;
                if (assemblyLine.Trim().EndsWith(":"))
                {
                    string label = assemblyLine.Trim();
                    label = label.Substring(0, label.Length - 1);
                    Address.Labels.Add(label, Address.CurrentAddress);
                    continue;
                }
                Address.GetAndIncreseAddress();
            }
        }

        public static InstructionType IdentifyInstructionType(string instruction)
        {
            instruction = instruction.Trim();
            if (string.IsNullOrEmpty(instruction))
                return InstructionType.EmptyLine;

            if (instruction.EndsWith(":"))
                return InstructionType.Lable;

            string op = instruction.Split(' ')[0];
            OpCode opCode = op.ToEnum<OpCode>();
            switch (opCode)
            {
                case (OpCode)0b0110011:
                    return InstructionType.R;
                case (OpCode)0b0010111:
                    return InstructionType.U;
                case (OpCode)0b0110111:
                    return InstructionType.U;
                case (OpCode)0b0010011:
                    return InstructionType.I;
                case (OpCode)0b1100011:
                    return InstructionType.B;
                case (OpCode)0b0000011:
                    return InstructionType.I;
                case (OpCode)0b0100011:
                    return InstructionType.S;
                case (OpCode)0b1101111:
                    return InstructionType.J;
                default:
                    return InstructionType.UnKnown;
            }
        }

        public static RiscVInstruction InstructionParser(string instruction, InstructionType type)
        {
            switch (type)
            {
                case InstructionType.R:
                    return (new R_Parser()).Parse(instruction);
                case InstructionType.I:
                    return (new I_Parser()).Parse(instruction);
                case InstructionType.S:
                    return (new S_Parser()).Parse(instruction);
                case InstructionType.B:
                    return (new B_Parser()).Parse(instruction);
                case InstructionType.U:
                    return (new U_Parser()).Parse(instruction);
                case InstructionType.J:
                    return (new J_Parser()).Parse(instruction);
                case InstructionType.Lable:
                    return (new Lable_Parser()).Parse(instruction);
                default:
                    return null;
            }
        }
    }
}
