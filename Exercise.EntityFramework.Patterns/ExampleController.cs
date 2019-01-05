using Exercise.EntityFramework.Patterns.Model;
using Exercise.EntityFramework.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.Patterns
{
    /// <summary>
    /// Example usage of your repositories in MVC Controller
    /// </summary>
    public class ExampleController
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Since there is already a DIC used here -> just request the repository.
        /// </summary>
        /// <param name="userRepository"></param>
        public ExampleController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> List()
        {
            return _userRepository.All();
        }
    }
}
