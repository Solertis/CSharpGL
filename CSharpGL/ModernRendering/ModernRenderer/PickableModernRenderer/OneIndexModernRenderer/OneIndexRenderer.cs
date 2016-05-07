﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 用glDrawElements进行渲染。
    /// </summary>
    public partial class OneIndexRenderer : PickableRenderer
    {
        protected OneIndexBufferPtr oneIndexBufferPtr;

        PrimitiveRestartSwitch primitiveRestartSwitch4Picking;

        /// <summary>
        /// 用glDrawElements进行渲染。
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal OneIndexRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            
        }

        protected override void DoInitialize()
        {
            // init index buffer 
            this.oneIndexBufferPtr = this.bufferable.GetIndex() as OneIndexBufferPtr;
            if (this.oneIndexBufferPtr == null) { throw new Exception(); }

            var primitiveRestartSwitch4Picking = new PrimitiveRestartSwitch(this.oneIndexBufferPtr);
            this.primitiveRestartSwitch4Picking = primitiveRestartSwitch4Picking;
            this.switchList4Picking.Add(primitiveRestartSwitch4Picking);

            base.DoInitialize();
        }

        public override IndexBufferPtr GetIndexBufferPtr()
        {
            return this.oneIndexBufferPtr;
        }

    }
}
