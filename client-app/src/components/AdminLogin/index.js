import React, { useState } from 'react';
import { Formik } from 'formik';
import './style.scss';


function AdminLogin({ setLoggedInValue }) {

    const [isLoading, setIsLoading] = useState(false);

    const initialValues = {
        username: "",
        password: "",
    };

    async function onSubmit() {
        setIsLoading(true);
        setTimeout(function () {
            setLoggedInValue("dziugas.mail@mail.com");
        }, 500);
    }

    return (
        <>
            <div className='login-main'>
                <div className='ui form-main grid container'>
                    <Formik {...{ initialValues, onSubmit }} className="nine wide column">
                        {({
                            getFieldProps,
                            handleSubmit,
                        }) => (
                            <>
                                <div className="formWrapper">
                                    <form className="baseForm" onSubmit={handleSubmit} noValidate>
                                        <header className="baseFormHeader">
                                            <h1 className="baseFormHeading">Login</h1>
                                        </header>

                                        <div >
                                            <label className="formFieldLabel" htmlFor="name">
                                                Email
                                            </label>
                                            <div >
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
                                                Password
                                            </label>
                                            <div>
                                                <input
                                                    className='inputField'
                                                    type="password"
                                                    id="password"
                                                    {...getFieldProps("password")}
                                                />
                                            </div>
                                        </div>

                                        <button className='btn btn-primary btn-lg btn-block' type="submit" disabled={isLoading}>
                                            <b>Login</b>
                                        </button>
                                        {
                                            isLoading ?
                                                <div className="ui active centered inline loader"></div>
                                                :
                                                null
                                        }
                                    </form>

                                </div>
                            </>
                        )}
                    </Formik>
                </div>
            </div>
        </>
    );
};
export default AdminLogin;
