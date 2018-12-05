Copyright 2014, CardConnect (http://www.cardconnect.com)

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH
REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT,
INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM
LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR
OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR
PERFORMANCE OF THIS SOFTWARE.
----

C# CardConnect REST Client Example Library

Requires:
 - JSON.net v6.0.1 - http://james.newtonking.com/json
 - RESTSharp v103.0.0 - http://restsharp.org

Download each required library and place extracted .dll files into a lib/ subdirectory.  Then
add to the project in Visual Studio by right clicking on the CardConnectRestClientExample
project name and selecting 'Add Reference...'.  Click on the 'Browse' tab and find the
.dll files, select them and clicke the 'OK' button.

Then modify the CardConnectRestClientExample.cs file and set the following variables:
 - ENDPOINT - Set to your site's base rest URL (eg: https://sitename.cardconnect.com:6443/cardconnect/rest/)
 - USERNAME - Your CardConnect API username
 - PASSWORD - Your CardConnect API password
