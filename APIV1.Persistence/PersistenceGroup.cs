using APIV1.Domain;
using Microsoft.EntityFrameworkCore;
using APIV1.Persistence.Context;

namespace APIV1.Persistence
{
    public class PersistenceGroup : IPersistenceGroup
    {
        private readonly APIV1Context _context;

        public PersistenceGroup(APIV1Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Group>?> GetAll()
        {
            try
            {
                return await _context.Group!.ToListAsync();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Group?> GetById(int id)
        {
            try
            {
                return await _context.Group!.FindAsync(id);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public async Task<Group?> GetByName(string name)
        {
            try
            {
                return await _context.Group!.FirstOrDefaultAsync(g => g.Name == name);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public async Task<Group?> Create(Group entity)
        {
            try
            {
                _context.Group!.Add(entity);
                _context.SaveChanges();
                return await this.GetById(entity.Id);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Group?> Update(Group entity)
        {
            try
            {
                _context.Group!.Update(entity);
                _context.SaveChanges();
                return await this.GetById(entity.Id);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }



        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await this.GetById(id);
                if (entity != null)
                {
                    _context.Group!.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;

            }
        }
    }
}
