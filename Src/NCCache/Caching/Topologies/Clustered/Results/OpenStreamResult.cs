//  Copyright (c) 2021 Alachisoft
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//     http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License
using Alachisoft.NCache.Runtime.Serialization;
using Alachisoft.NCache.Runtime.Serialization.IO;


namespace Alachisoft.NCache.Caching.Topologies.Clustered.Results
{
    
    internal class OpenStreamResult : ClusterOperationResult, ICompactSerializable
    {
        private bool _lockAcquired;

        public OpenStreamResult() { }

        public OpenStreamResult(Result executed, bool lockAcquired):base(executed)
        {
            _lockAcquired = lockAcquired;
        }

         public bool LockAcquired
        {
            get { return _lockAcquired; }
            set { _lockAcquired = value; }
        }



        #region ICompactSerializable Members

        public new void Deserialize(CompactReader reader)
        {
            base.Deserialize(reader);
            _lockAcquired = reader.ReadBoolean();
        }

        public new void Serialize(CompactWriter writer)
        {
            base.Serialize(writer);
            writer.Write(_lockAcquired);
        }

        #endregion
    }
}
