namespace find_players_with_zero_or_one_losses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // https://leetcode.com/problems/find-players-with-zero-or-one-losses/
        }
    }


    public class Solution
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            // winner = matches[0] and losser = matches[1] 
            // zero loss - winner to be added here if not present in one and more loss hash
            // one loss - losser will be added here if not already added here, in case losser is present in zero loss hash, need to remove from there and add here
            // morethanone loss - losser if present in one loss already, need to remove from there and add here, as this person lost more than one match

            HashSet<int> zeroLoss = new HashSet<int>();
            HashSet<int> oneLoss = new HashSet<int>();
            HashSet<int> moreLoss = new HashSet<int>();

            foreach (var match in matches)
            {
                int winner = match[0];
                int loser = match[1];

                // Add winner.
                if (!oneLoss.Contains(winner) && !moreLoss.Contains(winner))
                {
                    zeroLoss.Add(winner);
                }

                // Add or move loser.
                if (zeroLoss.Contains(loser))
                {
                    zeroLoss.Remove(loser);
                    oneLoss.Add(loser);
                }
                else if (oneLoss.Contains(loser))
                {
                    oneLoss.Remove(loser);
                    moreLoss.Add(loser);
                }
                else if (moreLoss.Contains(loser))
                {
                    continue;
                }
                else
                {
                    oneLoss.Add(loser);
                }
            }

            int[][] answer = new int[2][];
            answer[0] = zeroLoss.OrderBy(x => x).ToArray();
            answer[1] = oneLoss.OrderBy(x => x).ToArray();

            return answer;
        }
    }
}
