using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BufordCity.DAL.Entities;
using BufordCity.DAL.Repositories;
using BufordCity.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BufordCity.Controllers
{
    /// <summary>
    /// CRUD контроллер PeopleEntity
    /// </summary>
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private IDbRepository<PeopleEntity> _repository;
        public PeopleController(IDbRepository<PeopleEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        ///  создает объект
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public async Task<ActionResult> Create([FromBody] PeopleEntity people)
        {
            try
            {
                await _repository.CreateAsync(people);
                await _repository.SaveChangesAsync();
                return Ok($"Объект с {people.Id} создан");
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
            try
            {
                var peopleEntityResult = _repository.Get(h => h.IsActive && h.Id == id);
                var peopleEntity = peopleEntityResult.ToList().FirstOrDefault();
                if (peopleEntity == null)
                    return Ok($"Объект с ID {id} не найден");
                return Ok(peopleEntity);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// обновляет объект
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public async Task<ActionResult> Update([FromBody] PeopleEntity people)
        {
            try
            {
                _repository.Update(people);
                await _repository.SaveChangesAsync();
                return Ok($"Объект c {people.Id} обновлен");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// удалает объект
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var peopleEntityResult = _repository.Get(h => h.IsActive && h.Id == id);
                var peopleEntity = peopleEntityResult.ToList().FirstOrDefault();
                if (peopleEntity == null)
                    return Ok($"Объект с ID {id} не найден");
                _repository.Delete(peopleEntity);
                await _repository.SaveChangesAsync();
                return Ok("Объект {id} удален");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// создает несколько объектов за один запрос
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        [HttpPost, Route("createMany")]
        public async Task<ActionResult> CreateMany([FromBody] List<PeopleEntity> people)
        {
            try
            {
                await _repository.CreateManyAsync(people);
                await _repository.SaveChangesAsync();
                return Ok("Объекты созданы");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// возвращает все объекты PeopleEntity
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getAll")]
        public ActionResult GetAll()
        {
            string allPeoplesEntity = "";
            var result = _repository.GetAll().ToList();
            if (result == null)
                return Ok("Объекты не найдены");
            foreach (var people in result)
            {
                allPeoplesEntity += $"{people.Id}. {people.Name}";
            }

            return Ok(allPeoplesEntity);
        }
    }
}
