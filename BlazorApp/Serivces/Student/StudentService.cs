using BlazorApp.Serivces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Serivces.Student
{
    public class StudentService
    {
        private readonly IClient _client;

        public StudentService(IClient client)
        {
            _client = client;
        }

        public async Task<GetStudentDetailByIdResponse> GetStudentDetailById(int id)
        {
            return await _client.DetailAsync(id);
        }
    }
}
