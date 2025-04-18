using coding_challenge.Entities.Dtos;

namespace coding_challenge.Repositories;

public class MockTaskRepository : IMockTaskRepository
{
    #region Properties And Constructor

    private readonly List<Entities.Models.Task> tasks = new();
    private int _nextId = 1;

    public MockTaskRepository()
    {
        // Add additional tasks
        AddAdditionalTasks();
    }
    #endregion

    #region Crud Methods

    public IEnumerable<TaskDto> GetAll() => tasks.Select(e => new TaskDto(e));

    public TaskDto? GetById(int id) => tasks
        .FirstOrDefault(e => e.Id == id) is { } task
        ? new TaskDto(task)
    : null;

    public Entities.Models.Task Create(string title, string description, DateTime? dueDate)
    {
        var task = new Entities.Models.Task(
            _nextId++,
            title,
            description,
            false,
            DateTime.Now,
            dueDate
        );

        tasks.Add(task);
        return task;
    }

    public Entities.Models.Task Update(int id, string title, string description, bool isCompleted, DateTime? dueDate)
    {
        var existingTask = tasks.FirstOrDefault(t => t.Id == id);

        var updatedTask = new Entities.Models.Task(
            id,
            title,
            description,
            isCompleted,
            existingTask!.CreatedAt,
            dueDate
        );

        var index = tasks.FindIndex(t => t.Id == id);
        tasks[index] = updatedTask;

        return updatedTask;
    }

    public bool Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        tasks.Remove(task!);

        return true;
    }
    #endregion

    #region Helper Methods

    public bool IsExist(int id) => tasks.Any(e => e.Id == id);

    private void AddAdditionalTasks()
    {
        tasks.AddRange(new List<Entities.Models.Task>
        {
            new(_nextId++, "Refactor Task Service", "Improve code organization and maintainability", false, DateTime.Now, DateTime.Now.AddDays(12)),
            new(_nextId++, "Add Task Priority Levels", "Implement priority system for tasks", true, DateTime.Now, DateTime.Now.AddDays(15)),
            new(_nextId++, "Create Task Templates", "Add support for task templates", true, DateTime.Now, DateTime.Now.AddDays(20)),
            new(_nextId++, "Implement Task Comments", "Add comment system for tasks", false, DateTime.Now, DateTime.Now.AddDays(8)),
            new(_nextId++, "Add Task Attachments", "Support file attachments for tasks", false, DateTime.Now, DateTime.Now.AddDays(14)),
            new(_nextId++, "Create Task Reports", "Generate task completion reports", false, DateTime.Now, DateTime.Now.AddDays(18)),
            new(_nextId++, "Add Task Dependencies", "Implement task dependency system", false, DateTime.Now, DateTime.Now.AddDays(16)),
            new(_nextId++, "Setup Email Notifications", "Configure email notifications for task updates", false, DateTime.Now, DateTime.Now.AddDays(11)),
            new(_nextId++, "Implement Task Search", "Add advanced search functionality", false, DateTime.Now, DateTime.Now.AddDays(13)),
            new(_nextId++, "Add Task Tags", "Support tagging system for tasks", false, DateTime.Now, DateTime.Now.AddDays(7)),
            new(_nextId++, "Create Task Dashboard", "Build dashboard for task overview", false, DateTime.Now, DateTime.Now.AddDays(17)),
            new(_nextId++, "Implement Task Export", "Add export functionality for tasks", false, DateTime.Now, DateTime.Now.AddDays(19)),
            new(_nextId++, "Add Task Recurrence", "Support recurring tasks", false, DateTime.Now, DateTime.Now.AddDays(21)),
            new(_nextId++, "Create Task API Client", "Build client library for API", false, DateTime.Now, DateTime.Now.AddDays(22)),
            new(_nextId++, "Add Task Statistics", "Implement task completion statistics", false, DateTime.Now, DateTime.Now.AddDays(23)),
            new(_nextId++, "Setup Task Reminders", "Add reminder system for tasks", false, DateTime.Now, DateTime.Now.AddDays(24)),
            new(_nextId++, "Implement Task Sharing", "Add task sharing functionality", false, DateTime.Now, DateTime.Now.AddDays(25)),
            new(_nextId++, "Add Task Time Tracking", "Implement time tracking for tasks", false, DateTime.Now, DateTime.Now.AddDays(26)),
            new(_nextId++, "Create Task Templates", "Add support for task templates", false, DateTime.Now, DateTime.Now.AddDays(27)),
            new(_nextId++, "Implement Task Versioning", "Add version control for tasks", false, DateTime.Now, DateTime.Now.AddDays(28)),
            new(_nextId++, "Add Task Archiving", "Implement task archiving system", false, DateTime.Now, DateTime.Now.AddDays(29)),
            new(_nextId++, "Create Task Workflows", "Add custom task workflows", false, DateTime.Now, DateTime.Now.AddDays(30)),
            new(_nextId++, "Implement Task Approval", "Add task approval system", false, DateTime.Now, DateTime.Now.AddDays(31)),
            new(_nextId++, "Add Task Comments", "Implement comment system for tasks", false, DateTime.Now, DateTime.Now.AddDays(32)),
            new(_nextId++, "Create Task Analytics", "Add analytics for task performance", false, DateTime.Now, DateTime.Now.AddDays(33)),
            new(_nextId++, "Implement Task Integration", "Add integration with other tools", false, DateTime.Now, DateTime.Now.AddDays(34)),
            new(_nextId++, "Add Task Custom Fields", "Support custom fields for tasks", false, DateTime.Now, DateTime.Now.AddDays(35)),
            new(_nextId++, "Create Task API Documentation", "Generate API documentation", false, DateTime.Now, DateTime.Now.AddDays(36)),
            new(_nextId++, "Implement Task Permissions", "Add permission system for tasks", false, DateTime.Now, DateTime.Now.AddDays(37)),
            new(_nextId++, "Add Task History", "Implement task history tracking", false, DateTime.Now, DateTime.Now.AddDays(38)),
            new(_nextId++, "Optimize Task Loading", "Improve performance of task loading", false, DateTime.Now, DateTime.Now.AddDays(39)),
            new(_nextId++, "Add Task Filters", "Implement advanced filtering options", false, DateTime.Now, DateTime.Now.AddDays(40)),
            new(_nextId++, "Create Task Calendar View", "Add calendar visualization for tasks", false, DateTime.Now, DateTime.Now.AddDays(41)),
            new(_nextId++, "Implement Task Sorting", "Add multiple sorting options", false, DateTime.Now, DateTime.Now.AddDays(42)),
            new(_nextId++, "Add Task Progress Tracking", "Track progress of complex tasks", false, DateTime.Now, DateTime.Now.AddDays(43)),
            new(_nextId++, "Create Task Kanban Board", "Implement Kanban board view", false, DateTime.Now, DateTime.Now.AddDays(44)),
            new(_nextId++, "Add Task Checklists", "Support subtasks and checklists", false, DateTime.Now, DateTime.Now.AddDays(45)),
            new(_nextId++, "Implement Task Labels", "Add color-coded labels", false, DateTime.Now, DateTime.Now.AddDays(46)),
            new(_nextId++, "Create Task Timeline", "Add timeline view for tasks", false, DateTime.Now, DateTime.Now.AddDays(47)),
            new(_nextId++, "Add Task Templates Library", "Create library of task templates", false, DateTime.Now, DateTime.Now.AddDays(48)),
            new(_nextId++, "Implement Task Automation", "Add task automation rules", false, DateTime.Now, DateTime.Now.AddDays(49)),
            new(_nextId++, "Create Task Reports Dashboard", "Build dashboard for task reports", false, DateTime.Now, DateTime.Now.AddDays(50)),
            new(_nextId++, "Add Task Collaboration", "Enable team collaboration on tasks", false, DateTime.Now, DateTime.Now.AddDays(51)),
            new(_nextId++, "Implement Task Notifications", "Add real-time notifications", false, DateTime.Now, DateTime.Now.AddDays(52)),
            new(_nextId++, "Create Task Mobile App", "Develop mobile application", false, DateTime.Now, DateTime.Now.AddDays(53)),
            new(_nextId++, "Add Task Offline Support", "Enable offline task management", false, DateTime.Now, DateTime.Now.AddDays(54)),
            new(_nextId++, "Implement Task Sync", "Add multi-device sync", false, DateTime.Now, DateTime.Now.AddDays(55)),
            new(_nextId++, "Create Task Backup System", "Implement automatic backups", false, DateTime.Now, DateTime.Now.AddDays(56)),
            new(_nextId++, "Add Task Import/Export", "Support bulk operations", false, DateTime.Now, DateTime.Now.AddDays(57)),
            new(_nextId++, "Implement Task API Rate Limiting", "Add rate limiting to API", false, DateTime.Now, DateTime.Now.AddDays(58)),
            new(_nextId++, "Create Task Audit Log", "Track all task changes", false, DateTime.Now, DateTime.Now.AddDays(59)),
            new(_nextId++, "Add Task Security Features", "Implement security measures", false, DateTime.Now, DateTime.Now.AddDays(60)),
            new(_nextId++, "Implement Task Data Validation", "Add input validation", false, DateTime.Now, DateTime.Now.AddDays(61)),
            new(_nextId++, "Create Task Error Handling", "Improve error handling", false, DateTime.Now, DateTime.Now.AddDays(62)),
            new(_nextId++, "Add Task Performance Monitoring", "Monitor system performance", false, DateTime.Now, DateTime.Now.AddDays(63)),
            new(_nextId++, "Implement Task Caching", "Add caching layer", false, DateTime.Now, DateTime.Now.AddDays(64)),
            new(_nextId++, "Create Task Load Testing", "Perform load testing", false, DateTime.Now, DateTime.Now.AddDays(65)),
            new(_nextId++, "Add Task Security Testing", "Perform security testing", false, DateTime.Now, DateTime.Now.AddDays(66)),
            new(_nextId++, "Implement Task Accessibility", "Add accessibility features", false, DateTime.Now, DateTime.Now.AddDays(67)),
            new(_nextId++, "Create Task Localization", "Add multi-language support", false, DateTime.Now, DateTime.Now.AddDays(68)),
            new(_nextId++, "Add Task Dark Mode", "Implement dark theme", false, DateTime.Now, DateTime.Now.AddDays(69)),
            new(_nextId++, "Implement Task Custom Themes", "Add theme customization", false, DateTime.Now, DateTime.Now.AddDays(70)),
            new(_nextId++, "Create Task Keyboard Shortcuts", "Add keyboard navigation", false, DateTime.Now, DateTime.Now.AddDays(71)),
            new(_nextId++, "Add Task Drag and Drop", "Implement drag and drop functionality", false, DateTime.Now, DateTime.Now.AddDays(72)),
            new(_nextId++, "Implement Task Batch Operations", "Add bulk operations", false, DateTime.Now, DateTime.Now.AddDays(73)),
            new(_nextId++, "Create Task Search History", "Save search history", false, DateTime.Now, DateTime.Now.AddDays(74)),
            new(_nextId++, "Add Task Quick Actions", "Implement quick action buttons", false, DateTime.Now, DateTime.Now.AddDays(75)),
            new(_nextId++, "Implement Task Context Menu", "Add right-click menu", false, DateTime.Now, DateTime.Now.AddDays(76)),
            new(_nextId++, "Create Task Tooltips", "Add informative tooltips", false, DateTime.Now, DateTime.Now.AddDays(77)),
            new(_nextId++, "Add Task Help System", "Implement help documentation", false, DateTime.Now, DateTime.Now.AddDays(78)),
            new(_nextId++, "Implement Task Tutorial", "Add onboarding tutorial", false, DateTime.Now, DateTime.Now.AddDays(79)),
            new(_nextId++, "Create Task Feedback System", "Add user feedback mechanism", false, DateTime.Now, DateTime.Now.AddDays(80)),
            new(_nextId++, "Add Task User Surveys", "Implement user surveys", false, DateTime.Now, DateTime.Now.AddDays(81)),
            new(_nextId++, "Implement Task Analytics Dashboard", "Create analytics dashboard", false, DateTime.Now, DateTime.Now.AddDays(82)),
            new(_nextId++, "Create Task Usage Reports", "Generate usage reports", false, DateTime.Now, DateTime.Now.AddDays(83)),
            new(_nextId++, "Add Task Performance Metrics", "Track performance metrics", false, DateTime.Now, DateTime.Now.AddDays(84)),
            new(_nextId++, "Implement Task User Behavior Analysis", "Analyze user behavior", false, DateTime.Now, DateTime.Now.AddDays(85)),
            new(_nextId++, "Create Task A/B Testing", "Implement A/B testing", false, DateTime.Now, DateTime.Now.AddDays(86)),
            new(_nextId++, "Add Task Feature Flags", "Implement feature flags", false, DateTime.Now, DateTime.Now.AddDays(87)),
            new(_nextId++, "Implement Task Rollback System", "Add rollback capability", false, DateTime.Now, DateTime.Now.AddDays(88)),
            new(_nextId++, "Create Task Deployment Pipeline", "Setup deployment pipeline", false, DateTime.Now, DateTime.Now.AddDays(89)),
            new(_nextId++, "Add Task Monitoring Alerts", "Setup monitoring alerts", false, DateTime.Now, DateTime.Now.AddDays(90)),
            new(_nextId++, "Implement Task Logging System", "Add comprehensive logging", false, DateTime.Now, DateTime.Now.AddDays(91)),
            new(_nextId++, "Create Task Debug Tools", "Add debugging tools", false, DateTime.Now, DateTime.Now.AddDays(92)),
            new(_nextId++, "Add Task Performance Profiling", "Implement performance profiling", false, DateTime.Now, DateTime.Now.AddDays(93)),
            new(_nextId++, "Implement Task Memory Optimization", "Optimize memory usage", false, DateTime.Now, DateTime.Now.AddDays(94)),
            new(_nextId++, "Create Task Database Indexing", "Optimize database indexes", false, DateTime.Now, DateTime.Now.AddDays(95)),
            new(_nextId++, "Add Task Query Optimization", "Optimize database queries", false, DateTime.Now, DateTime.Now.AddDays(96)),
            new(_nextId++, "Implement Task Connection Pooling", "Add connection pooling", false, DateTime.Now, DateTime.Now.AddDays(97)),
            new(_nextId++, "Create Task Caching Strategy", "Implement caching strategy", false, DateTime.Now, DateTime.Now.AddDays(98)),
            new(_nextId++, "Add Task Load Balancing", "Implement load balancing", false, DateTime.Now, DateTime.Now.AddDays(99)),
            new(_nextId++, "Implement Task Failover System", "Add failover capability", false, DateTime.Now, DateTime.Now.AddDays(100)),
            new(_nextId++, "Create Task Backup Strategy", "Implement backup strategy", false, DateTime.Now, DateTime.Now.AddDays(101)),
            new(_nextId++, "Add Task Disaster Recovery", "Setup disaster recovery", false, DateTime.Now, DateTime.Now.AddDays(102)),
            new(_nextId++, "Implement Task Security Audit", "Perform security audit", false, DateTime.Now, DateTime.Now.AddDays(103)),
            new(_nextId++, "Create Task Compliance Report", "Generate compliance reports", false, DateTime.Now, DateTime.Now.AddDays(104)),
            new(_nextId++, "Add Task Data Encryption", "Implement data encryption", false, DateTime.Now, DateTime.Now.AddDays(105)),
            new(_nextId++, "Implement Task Access Control", "Add access control system", false, DateTime.Now, DateTime.Now.AddDays(106)),
            new(_nextId++, "Create Task Authentication System", "Implement authentication", false, DateTime.Now, DateTime.Now.AddDays(107)),
            new(_nextId++, "Add Task Authorization System", "Implement authorization", false, DateTime.Now, DateTime.Now.AddDays(108)),
            new(_nextId++, "Implement Task Session Management", "Add session management", false, DateTime.Now, DateTime.Now.AddDays(109)),
            new(_nextId++, "Create Task Password Policy", "Implement password policy", false, DateTime.Now, DateTime.Now.AddDays(110)),
            new(_nextId++, "Add Task Two-Factor Auth", "Implement 2FA", false, DateTime.Now, DateTime.Now.AddDays(111)),
            new(_nextId++, "Implement Task Single Sign-On", "Add SSO support", false, DateTime.Now, DateTime.Now.AddDays(112)),
            new(_nextId++, "Create Task API Gateway", "Implement API gateway", false, DateTime.Now, DateTime.Now.AddDays(113)),
            new(_nextId++, "Add Task Service Mesh", "Implement service mesh", false, DateTime.Now, DateTime.Now.AddDays(114)),
            new(_nextId++, "Implement Task Microservices", "Convert to microservices", false, DateTime.Now, DateTime.Now.AddDays(115)),
            new(_nextId++, "Create Task Containerization", "Containerize application", false, DateTime.Now, DateTime.Now.AddDays(116)),
            new(_nextId++, "Add Task Orchestration", "Implement orchestration", false, DateTime.Now, DateTime.Now.AddDays(117)),
            new(_nextId++, "Implement Task Scaling", "Add auto-scaling", false, DateTime.Now, DateTime.Now.AddDays(118)),
            new(_nextId++, "Create Task Monitoring", "Setup monitoring system", false, DateTime.Now, DateTime.Now.AddDays(119)),
            new(_nextId++, "Add Task Logging", "Implement logging system", false, DateTime.Now, DateTime.Now.AddDays(120)),
            new(_nextId++, "Implement Task Tracing", "Add distributed tracing", false, DateTime.Now, DateTime.Now.AddDays(121)),
            new(_nextId++, "Create Task Metrics", "Implement metrics collection", false, DateTime.Now, DateTime.Now.AddDays(122)),
            new(_nextId++, "Add Task Alerts", "Setup alerting system", false, DateTime.Now, DateTime.Now.AddDays(123)),
            new(_nextId++, "Implement Task Dashboard", "Create monitoring dashboard", false, DateTime.Now, DateTime.Now.AddDays(124)),
            new(_nextId++, "Create Task Documentation", "Write technical documentation", false, DateTime.Now, DateTime.Now.AddDays(125)),
            new(_nextId++, "Add Task User Guide", "Create user guide", false, DateTime.Now, DateTime.Now.AddDays(126)),
            new(_nextId++, "Implement Task API Docs", "Generate API documentation", false, DateTime.Now, DateTime.Now.AddDays(127)),
            new(_nextId++, "Create Task Training Materials", "Develop training materials", false, DateTime.Now, DateTime.Now.AddDays(128)),
            new(_nextId++, "Add Task Support System", "Setup support system", false, DateTime.Now, DateTime.Now.AddDays(129)),
            new(_nextId++, "Implement Task Feedback Loop", "Create feedback system", false, DateTime.Now, DateTime.Now.AddDays(130))
        });
    }
    #endregion
}
