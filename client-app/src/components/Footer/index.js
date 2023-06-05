import React from 'react';
import './styles.scss'

function Footer() {
    return (
        <footer className='footer mt-5'>
            <nav className='container d-flex align-items-center justify-content-center py-3 nav'>
                <li>
                    <img src='/images/logo_mobile.png' alt='Cocos' height='36' />
                </li>
                <li>
                    <span className='ico ico-logo'></span>
                </li>
                <li>
                    <a href='/'>Terms &amp; Conditions</a>
                </li>
                <li>
                    <a href='/'>Privacy Policy</a>
                </li>
                <li>
                    <a href='/' className='dark-blue'>Contacts</a>
                </li>
                <li>
                    <a href='/' className='dark-blue'>hotelhere@mail.com</a>
                </li>
                <li >
                    <a href='/' className='dark-blue'>Tel: +37062345295</a>
                </li>
                <li>
                    <div className='ico'></div>
                </li>
            </nav>
        </footer>
    )
}

export default Footer
