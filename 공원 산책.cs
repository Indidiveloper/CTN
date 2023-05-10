using System;

public class Solution
{
    public int[] solution(string[] park, string[] routes)
    {
        // 공원 크기, 시작 지점 초기화
        int h = park.Length;
        int w = park[0].Length;
        int x = 0, y = 0;

        for(int i = 0; i < h; i++)
        {
            for( int j = 0; j < w; j++)
            {
                if (park[i][j] == 'S')
                {
                    x = j;
                    y = i;
                    break;
                }
            }
        }

        // 반복문을 돌며 routes 실행
        for(int i = 0; i < routes.Length; i++)
        {
            int temp_X = x;
            int temp_Y = y;

            if (routes[i][0] == 'N')
            {
                temp_Y -= routes[i][2] - '0';
            }
            else if (routes[i][0] == 'S')
            {
                temp_Y += routes[i][2] - '0';
            }
            else if (routes[i][0] == 'W')
            {
                temp_X -= routes[i][2] - '0';
            }
            else if (routes[i][0] == 'E')
            {
                temp_X += routes[i][2] - '0';
            }

            // 공원 밖을 벗어나지 않은 경우에만 true
            if(temp_X < w && temp_X > -1 && temp_Y < h && temp_Y > -1)
            {
                bool isPossibel = true;

                // 가는 길에 장애물이 있는 경우 false
                if(temp_X > x)
                {
                    for(int j = x; j <= temp_X; j++)
                    {
                        if (park[y][j] == 'X')
                        {
                            isPossibel = false;
                            break;
                        }                        
                    }
                }
                else if(temp_X < x)
                {
                    for (int j = temp_X; j <= x; j++)
                    {
                        if (park[y][j] == 'X')
                        {
                            isPossibel = false;
                            break;
                        }
                    }
                }
                if (temp_Y > y)
                {
                    for (int j = y; j <= temp_Y; j++)
                    {
                        if (park[j][x] == 'X')
                        {
                            isPossibel = false;
                            break;
                        }
                    }
                }
                else if (temp_Y < y)
                {
                    for (int j = temp_Y; j <= y; j++)
                    {
                        if (park[j][x] == 'X')
                        {
                            isPossibel = false;
                            break;
                        }
                    }
                }

                // 조건을 모두 충족시켰을 경우 이동
                if(isPossibel == true)
                {
                    x = temp_X;
                    y = temp_Y;
                }
            }
        }
        int[] answer = new int[2] {y, x};
        return answer;
    }
}