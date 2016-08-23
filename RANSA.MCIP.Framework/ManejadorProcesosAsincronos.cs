using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Framework
{
    public class ManejadorProcesosAsincronos
    {
        List<Task> lstTask;

        public ManejadorProcesosAsincronos()
        {
            lstTask = new List<Task>();
        }
        /// <summary>
        /// Agrega un nuevo método para ser ejecutado asincronamente
        /// Nota: El método no debe ejecutar en su proceso una sesión.
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="lst"></param>
        /// <returns>Indice del proceso a ajecutarse</returns>
        public int Add<T>(List<T> lst)
        {
            int index = -1;
            Task<List<T>> lstTaskList = Task<List<T>>.Factory.StartNew(() => lst);

            lstTask.Add(lstTaskList);
            index = lstTask.Count - 1;
            return index;
        }

        public int AddSingle<T>(T obj)
        {
            int index = -1;
            Task<T> task = Task<T>.Factory.StartNew(() => obj);
            lstTask.Add(task);
            index = lstTask.Count - 1;
            return index;
        }

        public void Execute()
        {
            Task.WaitAll(lstTask.ToArray());
        }

        public List<T> GetResult<T>(int index)
        {
            Task<List<T>> rspt = (Task<List<T>>)lstTask[index];
            return rspt.Result;
        }

        public T GetResultSingle<T>(int index)
        {
            Task<T> rspt = (Task<T>)lstTask[index];
            return rspt.Result;
        }
    }
}
