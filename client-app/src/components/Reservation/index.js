import React, { useState } from 'react';
import { useSearchValue } from '../../store/SearchContext';
import { formatDateView } from '../../utils/formatDate';
import './style.scss';
import { Grid, Modal } from 'semantic-ui-react';

function Reservation() {
    const [data] = useSearchValue();
    const [discount, setDiscount] = useState(0);
    const { room, extra, step } = data;
    const { price } = room;
    const sum = (acc, cur) => acc + cur;
    const total = extra.length ? extra.map(el => el.price).reduce(sum, 0) + price : price;

    const [open, setOpen] = useState(false)


    function applyDiscount(value) {
        setDiscount(value);
    }

    if (step >= 3) {
        return (
            <section className='card'>
                <h2 className='mb-4'>
                    Reservation Summary
                </h2>
                <div className='d-flex justify-content-between'>
                    <h3>
                        {room.name}
                    </h3>
                </div>
                <div className='d-flex justify-content-between mb-3'>
                    <div>
                        <div className='font-weight-bold'>Check in</div>
                        <div>From 12.00h</div>
                    </div>
                    <div>
                        <div className='font-weight-bold'>Check out</div>
                        <div>Before 12.00h</div>
                    </div>
                </div>
                <div className='mb-3'>
                    <div className='font-weight-bold'>Reservation date</div>
                    <div>From <strong>{formatDateView(data.checkin)}</strong> to <strong>{formatDateView(data.checkout)}</strong></div>
                </div>
                <div className='mb-3'>
                    <div className='font-weight-bold'>People {data.adults}</div>
                </div>
                <div className='card-total'>
                    {discount > 0 && (
                        <>
                            <div>
                                <div>Promo Code</div>
                                <div>-{discount}%</div>
                            </div>
                            <div>
                                <div>Room Price</div>
                                <div>€ <del>{price}</del></div>
                            </div>
                        </>
                    )}
                    <div className='mb-3'>
                        <div>
                            <div className='price'>Total</div>
                        </div>
                        <div className='price'>€ {discount
                            ? (total - discount / 100 * total).toFixed(2)
                            : total}
                        </div>
                    </div>
                    {extra && extra.map(item => (
                        <div key={item.id}>
                            <div>{item.name}</div>
                            <div>€ {item.price}</div>
                        </div>
                    ))}
                </div>
                <div className='card-total'>
                    <img src='/images/discount.png' width='200' alt='' />
                    <h2 className='text-uppercase font-weight-bold'>TODAY ONLY: 10% OFF</h2>
                    <p>Enter promo <strong>HotelHere10</strong> and get an exclusive <strong>10% discount</strong> on your stay.</p>
                </div>
                <div className='formWrapper'>
                    <Grid className='gridStyl' textAlign='center'>
                        <Grid.Row>
                            <label className="formFieldLabel">
                                Enter promo code here
                            </label>
                        </Grid.Row>
                        <Grid.Row>
                            <Grid.Column width={6}>
                                <div >
                                    <input
                                        className='inputField'
                                        type="promo"
                                        id="promo"
                                    />
                                </div>
                            </Grid.Column>
                            <Grid.Column>
                                <Modal
                                    dimmer='blurring'
                                    size='mini'
                                    open={open}
                                    onClose={() => setOpen(false)}
                                    onOpen={() => setOpen(true)}
                                    trigger={
                                        <button
                                            disabled={Boolean(discount)}
                                            className='btn btn-primary btn-group-justified'
                                            type="submit"
                                            onClick={() => applyDiscount(10)}>
                                            Check
                                        </button>
                                    }
                                >
                                    <Modal.Header>PROMO CODE ACTIVATED</Modal.Header>
                                    <Modal.Content>
                                        <Modal.Description>
                                            10% off promo code has been activated.
                                        </Modal.Description>
                                    </Modal.Content>
                                    <Modal.Actions>
                                        <button
                                            className='btn btn-primary btn-group-justified'
                                            onClick={() => setOpen(false)}>
                                            Continue
                                        </button>
                                    </Modal.Actions>
                                </Modal>
                            </Grid.Column>
                        </Grid.Row>
                    </Grid>

                </div>
            </section>
        )
    }
    else return (<></>)
}

export default Reservation;