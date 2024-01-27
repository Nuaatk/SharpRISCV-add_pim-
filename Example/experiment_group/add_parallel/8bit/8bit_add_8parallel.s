.text
_start:
    addi sp,sp,-48
    sw	s0,44(sp)
    addi s0,sp,48
    la  a5,.LC0
    lw  a1,0(a5)
    lw  a2,4(a5)
    sw  a1,-24(s0)
    sw  a2,-20(s0)
    lw  a1,8(a5)
    lw  a2,12(a5)
    sw  a1,-32(s0)
    sw  a2,-28(s0)
	lbu	a4,-24(s0)
	lbu	a5,-32(s0)
	add	a5,a4,a5
	andi	a5,a5,255
	sb	a5,-40(s0)
	lbu	a4,-23(s0)
	lbu	a5,-31(s0)
	add	a5,a4,a5
	andi	a5,a5,255
	sb	a5,-39(s0)
	lbu	a4,-22(s0)
	lbu	a5,-30(s0)
	add	a5,a4,a5
	andi	a5,a5,255
	sb	a5,-38(s0)
	lbu	a4,-21(s0)
	lbu	a5,-29(s0)
	add	a5,a4,a5
	andi	a5,a5,0xff
	sb	a5,-37(s0)
	lbu	a4,-20(s0)
	lbu	a5,-28(s0)
	add	a5,a4,a5
	andi	a5,a5,0xff
	sb	a5,-36(s0)
	lbu	a4,-19(s0)
	lbu	a5,-27(s0)
	add	a5,a4,a5
	andi	a5,a5,0xff
	sb	a5,-35(s0)
	lbu	a4,-18(s0)
	lbu	a5,-26(s0)
	add	a5,a4,a5
	andi	a5,a5,0xff
	sb	a5,-34(s0)
	lbu	a4,-17(s0)
	lbu	a5,-25(s0)
	add	a5,a4,a5
	andi	a5,a5,0xff
	sb	a5,-33(s0)
    lw	s0,44(sp)
	addi	sp,sp,48
    addi    a0, x0, 0   # Use 0 return code
    addi    a7, x0, 93  # Service command code 93 terminates
    ecall               # Call linux to terminate the program
.data
.LC0:
	.word	67305985
	.word	134678021
	.word	50462976
	.word	117835012
.end