public static IEnumerable<Tuple<int, int>> PlanSchedule(IEnumerable<Tuple<int, int>> meetings)
{
	var leftEdge = int.MinValue;
	foreach (var meeting in meetings.OrderBy(m => m.Item2))
	{
		if (meeting.Item1 >= leftEdge)
		{
			leftEdge = meeting.Item2;
			yield return meeting;
		}
	}
}

public static IEnumerable<Edge> FindMinimumSpanningTree(IEnumerable<Edge> edges)
{
	var tree = new List<Edge>();
	foreach (var edge in edges.OrderBy(x => x.Weight))
	{
		tree.Add(edge);
		if (!HasCycle(tree))
		{
			continue;
		}
		else
		{
			tree.Remove(edge);
		}
			
	}
	return tree;
}