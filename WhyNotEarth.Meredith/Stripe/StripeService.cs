using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Stripe;
using WhyNotEarth.Meredith.Services;
using WhyNotEarth.Meredith.Stripe.Data;

namespace WhyNotEarth.Meredith.Stripe
{
    public class StripeService : StripeServiceBase, IStripeService
    {
        public StripeService(IOptions<StripeOptions> stripeOptions) : base(stripeOptions)
        {
        }

        public async Task<PaymentIntent> CreatePaymentIntent(string stripeAccountId, decimal amount, string email,
            Dictionary<string, string> metadata)
        {
            var paymentIntentService = new PaymentIntentService();

            var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = (int)(amount * 100),
                Currency = "usd",
                ApplicationFeeAmount = (int)Math.Ceiling(amount * 10m),
                Metadata = metadata,
                ReceiptEmail = email
            }, GetRequestOptions(stripeAccountId));

            return paymentIntent;
        }

        public PaymentIntent ConfirmPaymentIntent(string json, string stripSignatureHeader)
        {
            var stripeEvent = EventUtility.ConstructEvent(json, stripSignatureHeader, StripeOptions.EndpointSecret);

            if (stripeEvent.Type != Events.PaymentIntentSucceeded)
            {
                throw new StripeException("Invalid Stripe event.");
            }

            return (PaymentIntent)stripeEvent.Data.Object;
        }
    }
}