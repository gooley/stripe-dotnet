/*
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
using System.Globalization;
using System.Text;
using System.Web;

namespace Xamarin.Payments.Stripe
{
    public class StripeSubscriptionInfo
    {
        public string Plan { get; set; }
        public bool? Prorate { get; set; }

        public void UrlEncode(StringBuilder sb)
        {
            if (Plan != null)
                sb.AppendFormat("plan={0}&", HttpUtility.UrlEncode(Plan));
            if (Prorate.HasValue)
                sb.AppendFormat("prorate={0}&", Prorate.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }
    }
}
