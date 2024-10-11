class Async_Await
{
	public static async Task Main(string[] args)
	{
		Console.WriteLine("Main Method Started, with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);


		// Старт потоку
		Thread thread = new Thread(new ThreadStart(ThreadMethod));
		thread.Start();
		thread.Join();
		await Test();

		Console.WriteLine("After Test Method, with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);

		Console.WriteLine("Done");

	}

	private static void ThreadMethod()
	{
		Console.WriteLine("ThreadMethod Started with thread ID = " 
			+ Thread.CurrentThread.ManagedThreadId);

		for(int i = 0; i < 5; i++)
		{
			Console.WriteLine($"ThreadMethod: {i}");
			Thread.Sleep(1000);
		}

		Console.WriteLine("ThreadMethod Ended with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);
	}

	private static async Task Test()
	{
		Console.WriteLine("Test Method Started with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);

		await AssignResult();

		Console.WriteLine("After AssignResult Method, with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);
	}


	static async Task<int> AssignResult()
	{
		Console.WriteLine("AssignResult Method Started, with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);

		await Task.Delay(5000);

		Console.WriteLine("After Task.Delay, with thread ID = "
			+ Thread.CurrentThread.ManagedThreadId);

		return 0;	
	}
}