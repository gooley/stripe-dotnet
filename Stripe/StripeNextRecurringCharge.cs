﻿/*
 * Copyright 2011 Christopher Gooley
 *
 * Author(s):
 *  Christopher Gooley / FolioHD (gooley@foliohd.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using Newtonsoft.Json;

namespace Stripe {
    [JsonObject (MemberSerialization.OptIn)]
    public class StripeNextRecurringCharge {
        [JsonProperty (PropertyName = "amount")]
        public int Amount { get; set; }
        [JsonProperty (PropertyName = "date")]
        public string Date { get; set; }
    }
}
