.text
_start:
    la  a5,.LC0
    srli t1,sp,12
    addi t1,t1,1
    slli t2,t1,12
    lw  a1,0(a5)
    lw  a2,4(a5)
    sw  x0,0(x0)#转置存储开始
    sw  a1,0(t2)
    sw  a2,4(t2)
    addi t1,t1,1
    slli t2,t1,12
    lw  a1,8(a5)
    lw  a2,12(a5)
    sw  a1,0(t2)
    sw  a2,4(t2)
    sw  x0,0(x0)#转置存储结束
    addi a1,x0,2    #pim_start
    sw  a1,0(x0)
    addi a2,x0,1    #pim_compute 0b0000001
    sw  a2,0(t2)
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