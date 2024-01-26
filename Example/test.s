#
# Risc-V Assembler program to print "Hello World!"
# to stdout.
#
# a0-a2 - parameters to linux function services
# a7 - linux function number
# Linux System Calls https://marcin.juszkiewicz.com.pl/download/tables/syscalls.html
#

# Setup the parameters to print hello world
# and then call Linux to do it.
.text
_start: 
        addi  a0, x0, 1      # 1 = StdOut
        la    a1, .LC0 # load address of helloworld
        addi  a2, x0, 13     # length of our string
        addi  a7, x0, 64     # linux write system call
        ecall                # Call linux to output the string

# Setup the parameters to exit the program
# and then call Linux to do it.
	add	a5,a4,a5
        lw	s0,-44(sp)
        lw	s0,44(sp)
    	lbu	a5,26(s0)
        addi    a0, x0, 0   # Use 0 return code
        addi    a7, x0, 93  # Service command code 93 terminates
        ecall               # Call linux to terminate the program

.data
.LC0:
	.word 100
	.half 100
	.half  1000
