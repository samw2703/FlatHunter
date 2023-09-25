using FlatHunter.Core;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Threading;

namespace FlatHunter.Console;

internal static class TaskUtilities
{
    public static async Task<IEnumerable<T>> WhenAllBatches<T>(this IEnumerable<Task<T>> tasks, int batchSize = 1)
    {
        var taskList = tasks.ToList();
        using var semaphore = new SemaphoreSlim(batchSize);

        foreach (var task in taskList)
        {
            await semaphore.WaitAsync(); // Wait until we can acquire a semaphore slot.

            _ = task.ExecuteTaskWithSemaphore(semaphore);
        }

        // Wait for all tasks to complete.
        return await Task.WhenAll(taskList);
    }

    private static async Task<T> ExecuteTaskWithSemaphore<T>(this Task<T> task, SemaphoreSlim semaphore)
    {
        try
        {
            return await task;
        }
        finally
        {
            semaphore.Release();
        }
    }

    private static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks) => await Task.WhenAll(tasks);
}