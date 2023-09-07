﻿using System.Text.RegularExpressions;

class S_Parser : IParser
{
    public RiscVInstruction Parse(string instruction)
    {
        Regex sTypeRegex = new Regex(@"^(\w+)\s+(\w+),\s+(-?\d+)\((\w+)\)$");
        Match sTypeMatch = sTypeRegex.Match(instruction);
        if (sTypeMatch.Success)
        {
            return new RiscVInstruction
            {
                Opcode = sTypeMatch.Groups[1].Value,
                Rd = sTypeMatch.Groups[2].Value,
                Immediate = sTypeMatch.Groups[3].Value,
                Rs1 = sTypeMatch.Groups[4].Value,
                Rs2 = null,
                InstructionType = InstructionType.S,
            };
        }
        return null;
    }
}
