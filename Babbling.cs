using System;
using System.Globalization;

public class Solution
{
    public int solution(string[] babbling)
    {
        int answer = 0;

        // 발음 가능한 문자 :  "aya", "ye", "woo", "ma" 
        string[] possible = { "aya", "ye", "woo", "ma" };

        foreach (string b in babbling)
        {
            string remaining = "";

            // 문자열에서 발음 가능한 문자열이 포함된 경우 새 문자열에서 추가
            foreach (string p in possible)
            {
                if (b.Contains(p))
                {
                    remaining = remaining.Insert(remaining.Length, p);
                }
            }

            // 추가된 문자열과 기존 문자열을 같은 기준으로 정렬한다.
            char[] charB = b.ToCharArray();
            Array.Sort(charB);
            ReadOnlySpan<char> spanB = new ReadOnlySpan<char>(charB);

            char[] charR = remaining.ToCharArray();
            Array.Sort(charR);
            ReadOnlySpan<char> spanR = new ReadOnlySpan<char>(charR);

            // 추가된 문자열이 기존 문자열과 동일하다면 카운트 증가
            if (spanB.SequenceEqual(spanR))
            {
                answer++;
            }
        }


        return answer;
    }
}