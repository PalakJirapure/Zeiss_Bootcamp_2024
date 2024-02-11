# Test Specification for Supermarket Checkout

1.**Given** an empty cart **When** calculating the total price **Then** the total price should be 0.
    
2.**Given** a cart with a single item A **When** calculating the total price **Then** the total price should be 50.

3.**Given** a cart with items A, B, and C **When** calculating the total price **Then** the total price should be 115.(ABC)

4.**Given** a cart with three items A **When** calculating the total price **Then** the total price should be 130.(AAA)

5.**Given** a cart with two items B **When** calculating the total price **Then** the total price should be 45.(BB)

6.**Given** a cart with items (AAAABB) **When** calculating the total price **Then** the total price should be 225.

7.**Given** a cart with items (DABABA) **When** calculating the total price **Then** the total price should be 190.
  
8.**Given** a cart with items (AAABB) **When** calculating the total price **Then** the total price should be 175.

9.**Given** a cart with six items A **When** calculating the total price **Then** the total price should be 260.(AAAAAA)

10.**Given** a cart with items (ABCD) **When** calculating the total price **Then** the total price should be 130.

11.**Given** a cart with an invalid item E **When** calculating the total price **Then** an error (Invalid Item) should be raised.(E)

12.**Given** a cart with items (ABCDX) **When** calculating the total price **Then** an error (Invalid Item) should be raised.
