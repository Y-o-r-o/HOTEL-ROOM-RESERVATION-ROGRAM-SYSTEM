import { loadStripe } from '@stripe/stripe-js';

let stripePromise;
const getStripe = () => {
  if (!stripePromise) {
    stripePromise = loadStripe("pk_test_51N5T3PGhqP4dX9g3kRmFTb1pqAElHQm3SEUBb7r4TKenHCIDXoHh8qVpCIFDYfPIas6YxluTQYBTYTgmlPnvBEeV00eT1DkFuJ");
  }
  
  return stripePromise;
};

export default getStripe;
