/*
 * Copyright 2011 Xamarin, Inc & Christopher Gooley
 *
 * Author(s):
 * 	Gonzalo Paniagua Javier (gonzalo@xamarin.com)
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
using System.Collections.Generic;
using Stripe;

namespace PaymentTest {
    class Program {
        static void Main (string [] args)
        {
            StripeApi gateway = new StripeApi("YOURSECRETKEYGOESHERE");
            TestSimpleCharge(gateway);
            TestCustomer(gateway);
            TestCustomerAndCharge(gateway);
            TestGetCharges(gateway);
            TestGetCustomers(gateway);
        }

        static StripeCreditCardInfo GetCC ()
        {
            StripeCreditCardInfo cc = new StripeCreditCardInfo ();
            cc.CVC = "1234";
            cc.ExpirationMonth = 6;
            cc.ExpirationYear = 2012;
            cc.Number = "4242424242424242";
            return cc;
        }

        static void TestSimpleCharge(StripeApi gateway)
        {
            StripeCreditCardInfo cc = GetCC ();
            StripeCharge charge = gateway.Charge(5001, "usd", cc, "Test charge");
            Console.WriteLine (charge);
            string charge_id = charge.ID;
            StripeCharge charge_info = gateway.GetCharge(charge_id);
            Console.WriteLine (charge_info);
        }

        static void TestCustomer(StripeApi gateway)
        {
            StripeCustomerInfo customer = new StripeCustomerInfo ();
            //customer.Card = GetCC ();
            StripeCustomer customer_resp = gateway.CreateCustomer(customer);
            string customer_id = customer_resp.ID;
            StripeCustomer customer_info = gateway.GetCustomer(customer_id);
            Console.WriteLine (customer_info);
            StripeCustomer ci2 = gateway.DeleteCustomer(customer_id);
            if (ci2.Deleted == false)
                throw new Exception ("Failed to delete " + customer_id);
        }

        static void TestCustomerAndCharge(StripeApi gateway)
        {
            StripeCustomerInfo customer = new StripeCustomerInfo ();
            //customer.Card = GetCC ();
            StripeCustomer response = gateway.CreateCustomer(customer);
            string customer_id = response.ID;
            StripeCustomer customer_info = gateway.GetCustomer(customer_id);
            Console.WriteLine (customer_info);
            StripeCustomerInfo info_update = new StripeCustomerInfo ();
            info_update.Card = GetCC ();
            StripeCustomer update_resp = gateway.UpdateCustomer(customer_id, info_update);
            Console.Write ("Customer updated with CC. Press ENTER to continue...");
            Console.Out.Flush ();
            Console.ReadLine ();
            StripeCustomer ci2 = gateway.DeleteCustomer(customer_id);
            if (ci2.Deleted == false)
                throw new Exception ("Failed to delete " + customer_id);
        }

        static void TestGetCharges(StripeApi gateway)
        {
            List<StripeCharge> charges = gateway.GetCharges(0, 10);
            Console.WriteLine (charges.Count);
        }

        static void TestGetCustomers(StripeApi gateway)
        {
            List<StripeCustomer> customers = gateway.GetCustomers(0, 10);
            Console.WriteLine (customers.Count);
        }
    }
}
