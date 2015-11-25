﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackHole.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtensions
    {
        public static Matcher<T> Match<T>(this T obj) where T : class => new Matcher<T>(obj);
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class Matcher<T>
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        private bool m_matched;

        /// <summary>
        /// 
        /// </summary>
        public bool WasHandled => m_matched;

        /// <summary>
        /// 
        /// </summary>
        private T m_obj;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public Matcher(T obj)
        {
            m_obj = obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public Matcher<T> With<V>(Action<V> action) 
            where V : class, T
        {
            if (!m_matched)
            {
                V v = m_obj as V;
                if(v != null)
                {
                    action(v);
                    m_matched = true;
                }
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void Default(Action<object> action)
        {
            if (!m_matched)
                action(m_obj);
        }
    }    
}