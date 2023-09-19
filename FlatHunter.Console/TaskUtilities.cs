using FlatHunter.Core;

namespace FlatHunter.Console;

internal static class TaskUtilities
{
    public static async Task<IEnumerable<T>> WhenAllBatches<T>(this IEnumerable<Task<T>> tasks, int batchSize = 1)
    {
        var results = new List<T>();
        var taskList = tasks.ToList();
        var batchCount = (int)Math.Ceiling((decimal)taskList.Count / batchSize);
        for (int i = 0; i < batchCount; i++)
        {
            var isLastBatch = i == batchCount - 1;
            var skip = i * batchSize;
            var batch = isLastBatch
                ? taskList.Skip(skip)
                : taskList.Skip(skip).Take(batchSize);
            results.AddRange(await batch.WhenAll());
        }

        return results;
    }

    private static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks) => await Task.WhenAll(tasks);
}