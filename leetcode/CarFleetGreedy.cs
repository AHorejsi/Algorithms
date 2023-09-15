public class Solution {    
    public int CarFleet(int target, int[] positions, int[] speeds) {
        List<float> fleets =  Enumerable
            .Zip(positions, speeds)
            .OrderByDescending(((int position, int speed) data) => data.position) // Sort based on position so that fleets are adjacent to the fleets they would merge with first
            .Select(((int position, int speed) data) => (target - data.position) / (float)data.speed) // Calculate time it would take for each fleet to reach the end assuming no merges occur
            .ToList();
        int finishedCount = 1;
        float last = fleets[0];
        
        for (int index = 1; index < fleets.Count; ++index) {
            float current = fleets[index];
            
            // If the current fleet cannot reach the fleet ahead of it,
            // no fleet behind the current fleet can reach the fleet
            // ahead of the current fleet
            if (current > last) {
                ++finishedCount;
                last = current;
            }
        }
        
        return finishedCount;
    }
}
