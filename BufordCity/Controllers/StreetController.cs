using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BufordCity.DAL.Entities;
using BufordCity.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BufordCity.Controllers
{
    /// <summary>
    /// CRUD контроллер StreetEntity
    /// </summary>
    [ApiController]
    [Route("api/street")]
    public class StreetController : ControllerBase
    {
        private IDbRepository<StreetEntity> _repository;

        public StreetController(IDbRepository<StreetEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// создает объект
        /// </summary>
        /// <param name="street"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        public async Task<ActionResult> Create([FromBody] StreetEntity street)
        {
            try
            {
                await _repository.CreateAsync(street);
                await _repository.SaveChangesAsync();
                return Ok($"Объект с {street.Id} создан");
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
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var streetEntityResult = _repository.Get(h => h.IsActive && h.Id == id);
                var streetEntity = streetEntityResult.ToList().FirstOrDefault();
                if (streetEntity == null)
                    return Ok($"Объект с ID {id} не найден");
                return Ok(streetEntity);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// обновляет объект
        /// </summary>
        /// <param name="street"></param>
        /// <returns></returns>
        [HttpPost, Route("update")]
        public async Task<ActionResult> Update([FromBody] StreetEntity street)
        {
            try
            {
                _repository.Update(street);
                await _repository.SaveChangesAsync();
                return Ok($"Объект c {street.Id} обновлен");
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
                var streetEntityResult = _repository.Get(h => h.IsActive && h.Id == id);
                var streetEntity = streetEntityResult.ToList().FirstOrDefault();
                if (streetEntity == null)
                    return Ok($"Объект с ID {id} не найден");
                _repository.Delete(streetEntity);
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
        /// <param name="street"></param>
        /// <returns></returns>
        [HttpPost, Route("createMany")]
        public async Task<ActionResult> CreateMany([FromBody] List<StreetEntity> street)
        {
            try
            {
                await _repository.CreateManyAsync(street);
                await _repository.SaveChangesAsync();
                return Ok("Объекты созданы");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        /// <summary>
        /// возвращает все объекты StreetEntity
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getAll")]
        public  ActionResult GetAll()
        {
            string allStreetEntity = "";
            var result = _repository.GetAll().ToList();
            if (result == null)
                return Ok("Объекты не найдены");
            foreach (var street in result)
            {
                allStreetEntity += $"{street.Id}. {street.Name}";
            }

            return Ok(allStreetEntity);
        }
    }
}
