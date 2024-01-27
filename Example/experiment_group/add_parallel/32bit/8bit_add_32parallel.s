.text
_start:
    addi sp,sp,-48
    sw s0,44(sp)
    addi s0,sp,48
    la  a5,.LC0
    srli t1,sp,12
    addi t1,t1,1
    slli t2,t1,12
    lw  a1,0(a5)
    lw  a2,4(a5)
    lw  a3,8(a5)
    lw  a4,12(a5)
    sw  x0,0(x0) #转置存储开始
    sw  a1,0(t2)
    sw  a2,4(t2)
    sw  a3,8(t2)
    sw  a4,12(t2)
    lw  a1,16(a5)
    lw  a2,20(a5)
    lw  a3,24(a5)
    lw  a4,28(a5)
    sw  a1,16(t2)
    sw  a2,20(t2)
    sw  a3,24(t2)
    sw  a4,28(t2)
    addi t1,t1,1
    slli t2,t1,12
    lw  a1,32(a5)
    lw  a2,36(a5)
    lw  a3,40(a5)
    lw  a4,44(a5)
    sw  a1,0(t2)
    sw  a2,4(t2)
    sw  a3,8(t2)
    sw  a4,12(t2)
    lw  a1,48(a5)
    lw  a2,52(a5)
    lw  a3,56(a5)
    lw  a4,60(a5)
    sw  a1,16(t2)
    sw  a2,20(t2)
    sw  a3,24(t2)
    sw  a4,28(t2)
    sw  x0,0(x0)    #转置存储结束
    addi a1,x0,2    #pim_start
    sw  a1,0(x0)
    addi a2,x0,1    #pim_compute
    sw  a2,0(t1)
    addi    a0, x0, 0   # Use 0 return code
    addi    a7, x0, 93  # Service command code 93 terminates
    ecall               # Call linux to terminate the program
.data
.LC0:
	.word	67305985
	.word	134678021
	.word	303108105
	.word	370480147
    .word	67305985
	.word	134678021
	.word	303108105
	.word	370480147


    .word	50462976
	.word	117835012
	.word	286263560
	.word	353637138
    .word	50462976
	.word	117835012
	.word	286263560
	.word	353637138
.end