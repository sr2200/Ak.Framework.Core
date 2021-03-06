﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Reflection;
using System.Text;

namespace Akf.Core.Aspect.Parts
{
    [Export(typeof(IAkAspectParts))]
    internal class AkNoOperationAspect : IAkAspectParts
    {
        /// <summary>
        /// Pres the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="targetMethod">The target method.</param>
        /// <param name="instance"></param>
        /// <param name="args">The arguments.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void PreProcess<T>(Guid id, MethodInfo targetMethod, T instance, object[] args)
        {
            Console.WriteLine("{0} [{1}] {2}", 
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 
                                targetMethod.Name, 
                                "PreProcess");
        }

        /// <summary>
        /// Posts the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="targetMethod">The target method.</param>
        /// <param name="instance"></param>
        /// <param name="args">The arguments.</param>
        /// <param name="result">The result.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void PostProcess<T>(Guid id, MethodInfo targetMethod, T instance, object[] args, object result)
        {
            Console.WriteLine("{0} [{1}] {2}",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                targetMethod.Name,
                                "PostProcess");
        }

        /// <summary>
        /// Exceptions the process.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="targetMethod">The target method.</param>
        /// <param name="instance"></param>
        /// <param name="args">The arguments.</param>
        /// <param name="ex">The ex.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ExceptionProcess<T>(Guid id, MethodInfo targetMethod, T instance, object[] args, Exception ex)
        {
            Console.WriteLine("{0} [{1}] {2}",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                                targetMethod.Name,
                                "ExceptionProcess");
        }
    }
}
