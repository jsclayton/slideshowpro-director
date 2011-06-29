﻿// Copyright(c) 2011 John Clayton - http://codemonkeylabs.com
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

using System;
using System.Collections.Generic;

namespace SlideShowPro
{
    public class Album
    {
        public List<Content> Contents { get; set; }

        public DateTime Created { get; set; }

        public User Creator { get; set; }

        public string Description { get; set; }

        public long Id { get; set; }

        public DateTime Modified { get; set; }

        public string Name { get; set; }

        public Image Preview { get; set; }

        public User Public { get; set; }

        public string Tags { get; set; }

        public int TotalCount { get; set; }

        public User Updater { get; set; }
    }
}