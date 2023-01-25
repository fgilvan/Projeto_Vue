using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Data.Implementacao;
using ProjectSchool_API.Data.Interface;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    public abstract class ControllerBase<T> : Controller where T : ModelBase
    {
        public ControllerBase(IRepositoryBase<T> repository)
        {
            Repository = repository;
        }

        protected readonly IRepositoryBase<T> Repository;
        protected abstract string Rota { get; }

        [HttpPost]
        public virtual async Task<IActionResult> Post(T model)
        {
            try
            {
                Repository.Add(model);

                if (await Repository.SaveChangesAsync())
                {
                    return Created(Rota + model.Id, model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, T model)
        {
            try
            {
                var obj = await Repository.GetAsyncById(id);

                if (obj == null)
                    return NotFound();

                Repository.Update(model);

                if (await Repository.SaveChangesAsync())
                {
                    obj = await Repository.GetAsyncById(id);

                    return Created(Rota + model.Id, model);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await Repository.GetAsyncById(id);

                if (model == null)
                    return NotFound();

                Repository.Delete(model);

                if (await Repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }
    }
}