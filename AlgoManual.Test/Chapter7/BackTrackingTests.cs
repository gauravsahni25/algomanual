using AlgoManual.Chapter7.BasicBacktracks;
using NUnit.Framework;

namespace AlgoManual.Test.Chapter7
{
    public class BackTrackingTests
    {
        [Test]
        public void RunAllSubsets()
        {
            AllSubset program = new AllSubset();
            program.GenerateSubsets(3);
        }

        [Test]
        public void RunAllPermutations()
        {
            AllPermutations program = new AllPermutations();
            program.GeneratePermutations(3);
        }
    }
}
