class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.currentCount = currentCount;
        this.bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
            {
                return Points + bonus;
            }
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override string GetStatus() => $"[{currentCount}/{targetCount}]";

    public override string Serialize() =>
        $"ChecklistGoal|{Name}|{Description}|{Points}|{targetCount}|{currentCount}|{bonus}";
}
