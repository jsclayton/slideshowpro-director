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
using System.Net;
using RestSharp;

namespace SlideShowPro.Director
{
    public class SlideShowProException : Exception
    {

        internal SlideShowProException(IRestResponse response)
        {
            Body = response.Content;
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;
        }

        public string Body { get; set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string StatusDescription { get; private set; }

        public override string Message
        {
            get 
            {
                return String.Format("Server returned {0} ({1})", (int)StatusCode, StatusDescription);
            }
        }
    }
}