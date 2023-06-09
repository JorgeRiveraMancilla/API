namespace API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        // private readonly DataContext _dataContext;
        // private readonly IMapper _mapper;

        // public ProjectsController(DataContext dataContext, IMapper mapper)
        // {
        //     _dataContext = dataContext;
        //     _mapper = mapper;
        // }

        // [HttpGet]
        // public async Task<ActionResult<List<AppProject>>> GetProjects()
        // {
        //     var projects = await _dataContext.Projects
        //         .Include(p => p.Milestones)
        //         .ThenInclude(m => m.Activities)
        //         .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
        //         .ToListAsync();

        //     return Ok(projects);
        // }

        // [HttpGet("progress")]
        // public async Task<ActionResult<List<Object>>> GetProgress()
        // {
        //     var projects = await _dataContext.Projects
        //         .Include(p => p.Milestones)
        //         .ThenInclude(m => m.Activities)
        //         .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
        //         .ToListAsync();
            
        //     var progressProjects = new List<ProjectProgressDto>();

        //     foreach (var project in projects)
        //     {
        //         int numberMilestones = 0;
        //         int numberActivities = 0;

        //         int numberCompleted = 0;

        //         foreach (var milestone in project.Milestones)
        //         {
        //             foreach (var activity in milestone.Activities)
        //             {
        //                 if (activity.Status)
        //                     numberCompleted += 1;
        //                 numberActivities += 1;
        //             }

        //             numberMilestones += 1;
        //         }

        //         float progress = numberCompleted / (float) numberActivities;

        //         var projectProgress = new ProjectProgressDto
        //         {
        //             Id = project.Id,
        //             Code = project.Code,
        //             Name = project.Name,
        //             NumberMilestones = numberMilestones,
        //             NumberActivities = numberActivities,
        //             Progress = progress
        //         };

        //         progressProjects.Add(projectProgress);
        //     }

        //     return Ok(progressProjects);
        // }
    }
}