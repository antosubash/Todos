using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Dto;
using Todos.Permissions;
using Volo.Abp.Domain.Repositories;

namespace Todos
{
    public class TodoAppService : TodosAppService
    {
        private readonly IRepository<Todo, Guid> todoRepository;

        public TodoAppService(IRepository<Todo, Guid> todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        [Authorize(TodosPermissions.Todo.Default)]
        public async Task<List<TodoDto>> GetAll()
        {
            return ObjectMapper.Map<List<Todo>, List<TodoDto>>(await todoRepository.GetListAsync());
        }

        
        public async Task<TodoDto> CreateAsync(TodoDto todoDto)
        {
            var result = await AuthorizationService
                        .AuthorizeAsync(TodosPermissions.Todo.Create);

            if(result.Succeeded)
            {
                var todo = ObjectMapper.Map<TodoDto, Todo>(todoDto);
                var createdTodo = await todoRepository.InsertAsync(todo);
                return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
            }

            throw new UnauthorizedAccessException();
        }

        [Authorize(TodosPermissions.Todo.Update)]
        public async Task<TodoDto> UpdateAsync(TodoDto todoDto)
        {
            var todo = ObjectMapper.Map<TodoDto, Todo>(todoDto);
            var createdTodo = await todoRepository.UpdateAsync(todo);
            return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await AuthorizationService.CheckAsync(TodosPermissions.Todo.Delete);
            var todo = await todoRepository.FirstOrDefaultAsync(x=> x.Id == id);
            if(todo != null)
            {
                await todoRepository.DeleteAsync(todo);
                return true;
            }
            return false;
        }
    }
}
