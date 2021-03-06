public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>(asteroids.Length);
        
        foreach (int current in asteroids) {            
            if (0 != stack.Count) {
                int prev = stack.Peek();

                if (current < 0 && prev > 0) {
                    int currentPositive = -current;

                    if (currentPositive > prev) {
                        do {
                            stack.Pop();
                            
                            if (0 != stack.Count) {
                                prev = stack.Peek();
                            }
                            else {
                                break;
                            }
                        } while (prev > 0 && prev < currentPositive);
                    }
                    
                    if (currentPositive == prev) {
                        stack.Pop();
                    }
                    else if (currentPositive > prev) {
                        stack.Push(current);
                    }
                }
                else {
                    stack.Push(current);
                }
            }
            else {
                stack.Push(current);
            }
        }
        
        int[] result = stack.ToArray();
        Array.Reverse(result);
        
        return result;
    }
}