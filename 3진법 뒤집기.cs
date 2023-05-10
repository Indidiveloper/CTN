using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        string base3 = "";
        // 1. n을 3진법으로 나타낸다.
        while(n>0){
            // #. 이대로 문자열 변환 시 뒤집힌 형태
            base3 += (n%3).ToString();
            n/=3;
        }

        // 2. 뒤집힌 3진법 n을 다시 10진법 으로 나타낸다.
        for(int i = 0; i < base3.Length; ++i){
            int digit = int.Parse(base3[i].ToString());
            answer += digit * (int)Math.Pow(3, base3.Length - i - 1);
        }

        return answer;
    }
}