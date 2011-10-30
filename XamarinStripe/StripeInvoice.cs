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
using Newtonsoft.Json;

namespace Xamarin.Payments.Stripe {
    [JsonObject (MemberSerialization.OptIn)]
    public class StripeInvoice
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "period_end")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? PeriodEnd { get; set; }

        [JsonProperty(PropertyName = "period_start")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? PeriodStart { get; set; }

        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonProperty (PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty (PropertyName = "subtotal")]
        public int Subtotal { get; set; }

        [JsonProperty(PropertyName = "lines")]
        public StripeInvoiceLines InvoiceLines { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class StripeInvoiceLines
    {
        [JsonProperty(PropertyName = "invoiceitems")]
        public StripeInvoiceItem[] InvoiceItems { get; set; }

        [JsonProperty(PropertyName = "subscriptions")]
        public StripeInvoiceSubscription[] Subscriptions { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class StripeInvoiceSubscription
    {
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "plan")]
        public StripePlan Plan { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class StripeInvoiceItem
    {
        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }
}
