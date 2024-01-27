
int main()
{
    short input[3][3] ={{1, 2, 3},{4, 5, 6},{7, 8, 9}};//使用short类型，但实际位宽不能超过8
    short kernel[2][2] = {{1, 0}, {1, 0}};
    short output[3];

    output[0]= input[0][0]*kernel[0][0]+input[0][1]*kernel[0][1]+input[1][0]*kernel[1][0]+input[1][1]*kernel[1][1];
    output[1]= input[0][1]*kernel[0][0]+input[0][2]*kernel[0][1]+input[1][1]*kernel[1][0]+input[1][2]*kernel[1][1];
    output[2]= input[1][0]*kernel[0][0]+input[1][1]*kernel[0][1]+input[2][0]*kernel[1][0]+input[2][1]*kernel[1][1];
    output[3]= input[1][1]*kernel[0][0]+input[1][2]*kernel[0][1]+input[2][1]*kernel[1][0]+input[2][2]*kernel[1][1];

    return 0;
}