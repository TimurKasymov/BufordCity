using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BufordCity.DAL.Entities;
using BufordCity.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BufordCity.Controllers
{
    /// <summary>
    /// CRUD контроллер HomeEntity
    /// </summary>
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private IDbRepository<HomeEntity> _repository;
        public HomeController(IDbRepository<HomeEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        ///  создает объект
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public async Task<ActionResult> Creat([FromBody] HomeEntity home)
        {
            try
            {
                await _repository.CreateAsync(home);
                await _repository.SaveChangesAsync();
                return Ok($"Объект с {home.Name} создан");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// получает объект
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("get")]
        public async Task<ActionResult> Get([FromBody] int id)
        {
            var homeEntityResult = _repository.Get(h => h.IsActive && h.Id == id);
            var homeEntity =  homeEntityResult.ToList().FirstOrDefault();
            if (homeEntity == null)
                return Ok($"Объект с ID {id} не найден");
            return Ok(homeEntity);
        }
        /// <summary>
        /// обновляет объект
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public async Task<ActionResult> Update([FromBody] HomeEntity home)
        {
            try
            {
                _repository.Update(home);
                await _repository.SaveChangesAsync();
                return Ok($"Объект c {home.Id} обновлен");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        [HttpDelete, Route("delete")]
        public async Task<ActionResult> Delete([FromBody] HomeEntity home)
        {
            try
            {
                var homeEntityResult = _repository.Get(h => h.IsActive && h.Id == home.Id);
                var homeEntity = homeEntityResult.ToList().FirstOrDefault();
                if (homeEntity == null)
                    return Ok($"Объект с ID {home.Id} не найден");
                _repository.Delete(homeEntity);
                await _repository.SaveChangesAsync();
                return Ok($"Объект {home.Id} удален");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// создает несколько объектов за один запрос
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
        [HttpPost, Route("createMany")]
        public async Task<ActionResult> CreateMany([FromBody] List<HomeEntity> home)
        {
            try
            {
                await _repository.CreateManyAsync(home);
                await _repository.SaveChangesAsync();
                return Ok("Объекты созданы");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// возвращает все объекты HomeEntity
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getAll")]
        public ActionResult GetAll()
        {
            string allHomeEntity = "";
            var result = _repository.GetAll().ToList();
            if (result == null)
                return Ok("Объекты не найдены");
            foreach (var street in result)
            {
                allHomeEntity += $"{street.Id}. {street.Name}";
            }

            return Ok(allHomeEntity);
        }
    }
}
