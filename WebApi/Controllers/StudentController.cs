using Application.Features.CourseFeatures.Commands;
using Application.Features.CourseFeatures.Queries;
using Application.Features.StudentFeatures.Queries;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class StudentController : BaseApiController
    {
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string orderBy, string? search)
        {
            return Ok(await Mediator.Send(new GetAllStudentsQuery(pageNumber, pageSize, orderBy, search)));
        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetStudentDetailByIdQuery { ID = id }));
        }

        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detail/{id}")]
        public async Task<ActionResult<GetStudentDetailByIdResponse>> GetStudentDetailById(int id)
        {
            return Ok(await Mediator.Send(new GetStudentDetailByIdQuery { ID = id }));
        }
        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteStudentByIdCommand { ID = id }));
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
