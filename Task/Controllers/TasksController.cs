using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<ModelTask> modelTasks =
            new List<ModelTask>();






        [HttpGet]
        public ActionResult<List<ModelTask>> 
        SearchTasks()
        {
            return Ok(modelTasks);
        }






        [HttpPost]
        public ActionResult<List<ModelTask>>
        AddTask(ModelTask newTask)
        {
            if (newTask.Description.Length < 10) 
                return BadRequest("Adicione pelomenos 10 carateres!");

            newTask.Id = modelTasks.Count > 0 ? modelTasks[modelTasks.Count - 1].Id + 1 : 1;

            modelTasks.Add(newTask);
            return Ok(modelTasks);
        }
         

        [HttpDelete("{id}")]
        public ActionResult<List<ModelTask>> 
        DeleteTask(int id)
        {
            var taskDelete = modelTasks.FirstOrDefault(t => t.Id == id);

            if (taskDelete == null)
            {
                return NotFound("Tarefa não encontrada");
            }

            modelTasks.Remove(taskDelete);

            return Ok(modelTasks);
        }
    }
}
