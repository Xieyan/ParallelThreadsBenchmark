using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBenchmarks
{
    public class ParalleTest
    {
        public async Task MaxParalle(int maxThreadNum)
        {
            var outputList = Enumerable.Range(1, 200).Select(s => $"_{maxThreadNum}_{s}.txt").ToList();
            await Parallel.ForEachAsync(
                outputList,
                new ParallelOptions { MaxDegreeOfParallelism = maxThreadNum },
                async (output, cancellationToken) =>
                {
                    try
                    {
                        await Task.Delay(1);
                        using FileStream fs = new FileStream($"c:\\perftest\\{output}", FileMode.Create);
                        using StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
                        w.Write("There are also a lot of different statistics which can be considered. It will be really hard to analyse the summary table, if all of the available statistics will be shown. Fortunately, BenchmarkDotNet has some heuristics for statistics columns and shows only important columns. For example, if all of the standard deviations are zero (we run our benchmarks against Dry job), this column will be omitted. The standard error will be shown only for cases when we are failed to achieve required accuracy level.");
                    }
                    catch (Exception)
                    {
                        // Do nothing.
                    }
                });
        }
    }
}
