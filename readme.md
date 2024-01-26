# SharpRISCV #
- 增加数据段对.half类型的支持

![img2](.\img2.jpg)

测试.s代码位于Example



- 命令符与寄存器之间不能存在制表符

  - 原因：string op = instruction.Split(' ')[0];在解析opcode的时候通过空格划分，识别不了制表符

  - 解决：在IdentifyInstructionType中对输入的指令进行"\t"与" "的转换

- load类指令不支持负数寻址
