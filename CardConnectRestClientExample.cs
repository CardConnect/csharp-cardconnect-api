using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CardConnectRestClientExample
{
    class CardConnectRestClientExample
    {
        private static String ENDPOINT = "https://sitename.prinpay.com:6443/cardconnect/rest";
        private static String USERNAME = "username";
        private static String PASSWORD = "password123";

        public static void Main(String[] args) {
            // Send an Auth Transaction request
            String retref = authTransaction();
            // Void transaction
            voidTransaction(retref);

            // Send an Auth Transaction w/ user fields
            retref = authTransactionWithUserFields();
            // Inquire transaction
            inquireTransaction(retref);

            // Send an Auth w/ Capture
            retref = authTransactionWithCapture();
            // Void 
            voidTransaction(retref);

            // Send normal Auth
            retref = authTransaction();
            // Explicit capture
            captureTransaction(retref);

            // Settlement Status
            settlementStatusTransaction();

            // Deposit Status
            depositTransaction();

            // Auth with Profile
            String profileid = authTransactionWithProfile();

            // Get profile
            getProfile(profileid);

            // Delete profile
            deleteProfile(profileid);

            // Create profile
            addProfile();

            Console.ReadLine();
        }

        /**
        * Authorize Transaction REST Example
        * @return
        */
        public static String authTransaction() {
            Console.WriteLine("\nAuthorization Request");
            
            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("Street", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");
            
            // Create the REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an AuthTransaction request
            JObject response = client.authorizeTransaction(request);
            
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
            
            return (String)response.GetValue("retref");
        }

        /**
        * Authorize Transaction with User Fields REST Example
        * @return
        */
        public static String authTransactionWithUserFields() {
            Console.WriteLine("\nAuthorization With User Fields Request");
            
            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("Street", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");
            
            // Create user fields
            JArray fields = new JArray();
            JObject field = new JObject();
            field.Add("Field1", "Value1");
            fields.Add(field);
            request.Add("userfields", fields);
            
            // Create the REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an AuthTransaction request
            JObject response = client.authorizeTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
            
            return (String)response.GetValue("retref");
        }


        /**
         * Authorize Transaction With Capture REST Example
         * @return
         */
        public static String authTransactionWithCapture() {
            Console.WriteLine("\nAuthorization With Capture Request");
            
            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("Street", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");
            // Capture auth
            request.Add("capture", "Y");
            
            // Create the REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an AuthTransaction request
            JObject response = client.authorizeTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
            
            return (String)response.GetValue("retref");
        }


        /**
         * Authorize Transaction with Profile REST Example
         * @return
         */
        public static String authTransactionWithProfile() {
            Console.WriteLine("\nAuthorization With Profile Request");
            
            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("Street", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");
            // Create Profile
            request.Add("profile", "Y");
            
            // Create the REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an AuthTransaction request
            JObject response = client.authorizeTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
            
            return (String)response.GetValue("profileid");
        }


        /**
         * Capture Transaction REST Example
         * @param retref
         */
        public static void captureTransaction(String retref) {
            Console.WriteLine("\nCapture Transaction Request");
            
            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("retref", retref);
            // Purchase Order Number
            request.Add("ponumber", "12345");
            // Tax Amount
            request.Add("taxamnt", "007");
            // Ship From ZipCode
            request.Add("shipfromzip", "11111");
            // Ship To Zip
            request.Add("shiptozip", "11111");
            // Ship to County
            request.Add("shiptocountry", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            
            // Line item details
            JArray items = new JArray();
            // Singe line item
            JObject item = new JObject();
            item.Add("lineno", "1");
            item.Add("material", "12345");
            item.Add("description", "Item Description");
            item.Add("upc", "0001122334455");
            item.Add("quantity", "5");
            item.Add("uom", "each");
            item.Add("unitcost", "020");
            items.Add(item);
            // Add items to request
            request.Add("items", items);
            
            // Authorization Code from auth response
            request.Add("authcode", "0001234");
            // Invoice ID
            request.Add("invoiceid", "0123456789");
            // Order Date
            request.Add("orderdate", "20140131");
            // Total Order Freight Amount
            request.Add("frtamnt", "1");
            // Total Duty Amount
            request.Add("dutyamnt", "1");
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send a captureTransaction request
            JObject response = client.captureTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
        }


        /**
         * Void Transaction REST Example
         * @param retref
         */
        public static void voidTransaction(String retref) {
            Console.WriteLine("\nVoid Transaction Request");
            
            // Create Update Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Transaction amount
            request.Add("amount", "0");
            // Transaction currency
            request.Add("currency", "USD");
            // Return Reference code from authorization request
            request.Add("retref", retref);
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send a voidTransaction request
            JObject response = client.voidTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
        }


        /**
         * Refund Transaction REST Example
         * @param retref
         */
        public static void refundTransaction(String retref) {
            Console.WriteLine("\nRefund Transaction Request");
            
            // Create Update Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Transaction amount
            request.Add("amount","-100");
            // Transaction currency
            request.Add("currency", "USD");
            // Return Reference code from authorization request
            request.Add("retref", retref);
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an refundTransaction request
            JObject response = client.refundTransaction(request);
            
            // Handle response
            foreach (var x in response) {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }
        }


        /**
         * Inquire Transaction REST Example
         * @param retref
         */
        public static void inquireTransaction(String retref) {
            Console.WriteLine("\nInquire Transaction Request");
            String merchid = "496400000840";
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Send an inquire Transaction request
            JObject response = client.inquireTransaction(merchid, retref);
            
            // Handle response
            if (response != null) {
                foreach (var x in response) {
                    String key = x.Key;
                    JToken value = x.Value;
                    Console.WriteLine(key + ": " + value.ToString());
                }
            }
        }


        /**
         * Settlement Status REST Example
         */
        public static void settlementStatusTransaction() {
            Console.WriteLine("\nSettlement Status Transaction Request");
            // Merchant ID
            String merchid = "496400000840";
            String date = "0401";
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            JArray responses = client.settlementStatus(merchid, date);
            //JSONArray responses = client.settlementStatus(null, null);
            
            // Handle response
            if (responses != null) {
                foreach (JObject response in responses) { 
                    foreach (var x in response) {
                        String key = x.Key;
                        JToken value = x.Value;
                        if ("txns".Equals(key)) {
                            Console.WriteLine("transactions: ");
                            foreach (JObject txn in value) {
                                Console.WriteLine("  ===");
                                foreach (var t in txn) {
                                    String tkey = t.Key;
                                    JToken tvalue = t.Value;
                                    Console.WriteLine("  " + tkey + ": " + tvalue.ToString());
                                }
                            }
                        } else {
                            Console.WriteLine(key + ": " + response.GetValue(key));
                        }
                    }
                }
            }
        }


        /** 
         * Deposit Transaction REST Example
         */
        public static void depositTransaction() {
            Console.WriteLine("\nDeposit Transaction Request");
            // Merchant ID
            String merchid = "496400000840";
            // Date
            String date = "20140131";
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            JObject response = client.depositStatus(merchid, date);
            
            // Handle response
            if (response != null) {
                foreach (var x in response) {
                    String key = x.Key;
                    JToken value = x.Value;
                    if ("txns".Equals(key)) {
                        Console.WriteLine("transactions: ");
                        foreach (JObject txn in value) {
                            Console.WriteLine("  ===");
                            foreach (var t in txn) {
                                String tkey = t.Key;
                                JToken tvalue = t.Value;
                                Console.WriteLine("  " + tkey + ": " + tvalue.ToString());
                            }
                        }
                    } else {
                        Console.WriteLine(key + ": " + response.GetValue(key));
                    }
                }
            }
        }


        /**
         * Get Profile REST Example
         * @param profileid
         */
        private static void getProfile(String profileid) {
            Console.WriteLine("\nGet Profile Request");
            // Merchant ID
            String merchid = "496400000840";
            // Account ID
            String accountid = "1";
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Retrieve profile from Profile Service
            JArray response = client.profileGet(profileid, accountid, merchid);
            
            // Handle response
            if (response != null)
            {
                foreach (JObject obj in response)
                {
                    foreach (var x in obj)
                    {
                        String xkey = x.Key;
                        JToken xvalue = x.Value;
                        Console.WriteLine(xkey + ": " + xvalue.ToString());
                    }
                }
            }
        }


        /**
         * Delete Profile REST Example
         * @param profileid
         */
        private static void deleteProfile(String profileid) {
            Console.WriteLine("\nDelete Profile Request");
            // Merchant ID
            String merchid = "496400000840";
            String accountid = "";
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Delete profile using Profile Service
            JObject response = client.profileDelete(profileid, accountid, merchid);
            
            // Handle response
            if (response != null) {
                foreach (var x in response)
                {
                    String xkey = x.Key;
                    JToken xvalue = x.Value;
                    Console.WriteLine(xkey + ": " + xvalue.ToString());
                }
            }
        }


        /**
         * Add Profile REST Example
         */
        private static void addProfile() {
            Console.WriteLine("\nAdd Profile Request");
            
            // Create Profile Request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "496400000840");
            // Default account
            request.Add("defaultacct", "Y");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("address", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            
            // Create the CardConnect REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);
            
            // Create profile using Profile Service
            JObject response = client.profileCreate(request);
            
            // Handle response
            foreach (var x in response)
            {
                String xkey = x.Key;
                JToken xvalue = x.Value;
                Console.WriteLine(xkey + ": " + xvalue.ToString());
            }
        }
    }
}
