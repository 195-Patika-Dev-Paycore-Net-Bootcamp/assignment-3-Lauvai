using Container.Context;
using Container.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace Container.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession session;
        public ContainerController(IMapperSession session)
        {
            this.session = session;
        }

        [HttpGet]
        public List<ContainerModel> Get()
        {
            List<ContainerModel> result = session.Containers.ToList();
            return result;
        }

        [HttpGet("{id}")]
        public ContainerModel Get(int id)
        {
            ContainerModel result = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] ContainerModel container)
        {
            try
            {
                session.BeginTransaction();
                session.Save(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Container Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
        }

        [HttpPut]
        public ActionResult<ContainerModel> Put([FromBody] ContainerModel request)
        {
            ContainerModel container = session.Containers.Where(x => x.Id == request.Id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;
                container.VehicleId = request.VehicleId;

                session.Update(container);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Container Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<ContainerModel> Delete(int id)
        {
            ContainerModel container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Container Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();
        }
    }
}
