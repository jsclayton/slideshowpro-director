// Copyright(c) 2011 John Clayton - http://codemonkeylabs.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License. 

namespace SlideShowPro.Director
{
    public class User
    {
        public int ContentCount { get; set; }

        public User Creator { get; set; }

        public string DisplayName { get; set; }

        public string First { get; set; }

        public long Id { get; set; }

        public string Last { get; set; }

        public int Photos { get; set; }

        public string Profile { get; set; }

        public User Public { get; set; }

        public string Username { get; set; }

        public User Updater { get; set; }
    }
}