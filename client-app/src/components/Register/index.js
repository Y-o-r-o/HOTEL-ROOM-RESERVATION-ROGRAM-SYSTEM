import React, { useContext, useState } from 'react';
import { SearchContext } from '../../store/SearchContext';
import { Formik } from "formik";
import './style.scss';
import Select from "react-select";
import getStripe from 'utils/getStripe';
import emailjs from '@emailjs/browser';

function Register() {

    const banks = [
        "Swedbank",
        "SEB",
        "Luminor",
        "Šiaulių bankas",
        "Citadele",
        "Visa/MasterCard"
    ].map((label) => ({ label, value: label.toLowerCase() }));

    const initialValues = {
        name: "",
        surname: "",
        email: "",
        phone: "",
        transactionToken: "",
    };
    
    const sendEmail = () => {
        emailjs.send("service_62isugs", "template_vsouwjf", {
            emailgetter: "dziugas.mail@mail.com",
        }, 'gmIdE3NrS0n885XAp').then((result) => {
            console.log(result.text);
        }, (error) => {
            console.log(error.text);
        });
    };

    async function onSubmit() {

        const stripe = await getStripe();

        dispatch({
            type: 'changeSearch',
            payload: {
                step: 0
            }
        })

        sendEmail();

        const { error } = stripe.redirectToCheckout({
            lineItems: [
                {
                    price: "price_1N6KzlGhqP4dX9g33kRpbDi1",
                    quantity: 1,
                },
            ],
            mode: 'payment',
            successUrl: `http://localhost:3000`,
            cancelUrl: `http://localhost:3000`,
            customerEmail: 'dziugas.g99@gmail.com',
            
        });
        console.warn(error.message);

    }

    const [data, dispatch] = useContext(SearchContext);
    const { step } = data;
    const [isChecked, setIsChecked] = useState(false);

    if (step !== 3) return null;

    return (
        <div>
            <Formik {...{ initialValues, onSubmit }} className="form-main">
                {({
                    getFieldProps,
                    handleSubmit
                }) => (
                    <>
                        <div className="formWrapper">
                            <form className="baseForm" onSubmit={handleSubmit} noValidate>
                                <header className="baseFormHeader">
                                    <h1 className="baseFormHeading">Register Form</h1>
                                </header>

                                <div >
                                    <label className="formFieldLabel" htmlFor="name">
                                        Name of the payer
                                    </label>
                                    <div >
                                        <input
                                            className='inputField'
                                            type="name"
                                            id="name"
                                            {...getFieldProps("name")}
                                        />
                                    </div>
                                </div>

                                <div >
                                    <label className="formFieldLabel">
                                        Surname of the payer
                                    </label>
                                    <div>
                                        <input
                                            className='inputField'
                                            type="surname"
                                            id="surname"
                                            {...getFieldProps("surname")}
                                        />
                                    </div>
                                </div>

                                <div >
                                    <label className="formFieldLabel">
                                        Email
                                    </label>
                                    <div>
                                        <input
                                            className='inputField'
                                            type="email"
                                            id="email"
                                            {...getFieldProps("email")}
                                        />
                                    </div>
                                </div>

                                <div >
                                    <label className="formFieldLabel">
                                        Phone number
                                    </label>
                                    <div>
                                        <input
                                            className='inputField'
                                            type="phoneNumber"
                                            id="phoneNumber"
                                            {...getFieldProps("phoneNumber")}
                                        />
                                    </div>
                                </div>

                                <div>
                                    <label className="formFieldLabel">
                                        Select your payment method
                                    </label>
                                    <Select options={banks} />
                                </div>

                                <div >
                                    <div className="checkbox-wrapper">
                                        <label>
                                            <input
                                                className='inputField'
                                                type="checkbox"
                                                checked={isChecked}
                                                onChange={() => setIsChecked((prev) => !prev)}
                                            />
                                            <span>I agree to terms & conditins</span>
                                        </label>
                                    </div>
                                </div>

                                <button className='btn btn-primary btn-group-justified' onClick={() => onSubmit()} disabled={!isChecked}>
                                    Checkout
                                </button>
                            </form>

                        </div>
                    </>
                )}
            </Formik>

            <button
                onClick={ev => {
                    dispatch({
                        type: 'changeSearch',
                        payload: {
                            step: (step <= 1 ? 1 : step - 1)
                        }
                    })
                }}
                className='btn btn-primary btn-group-justified'
            >
                &lt; Back
            </button>
        </div>

    )
}

export default Register;








