import React, { useEffect, useState } from 'react';
import './style.scss';
import data from '../../store/Data/administrators.json';
import { useFormik } from 'formik';
import { Modal } from 'semantic-ui-react';
import emailjs from '@emailjs/browser';

function AdminAdministrator({ loggedInAs }) {

    const [items, setItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [open, setOpen] = useState(false)

    const [rid, setId] = useState("");
    const [rname, setName] = useState("");
    const [rsurname, setSurname] = useState("");
    const [rnumber, setNumber] = useState("");
    const [remail, setEmail] = useState("");


    const sendEmail = (value) => {
        emailjs.send("service_62isugs", "template_8u4hbwa", {
            emailgetter: value.email,
            name: value.name,
            surnme: value.surname,
        }, 'gmIdE3NrS0n885XAp').then((result) => {
            console.log(result.text);
        }, (error) => {
            console.log(error.text);
        });
    };

    const formikCreate = useFormik({
        initialValues: {
            name: "",
            surname: "",
            number: "",
            email: ""
        },
        onSubmit: value => {
            addItem(value);
            sendEmail(value);
        },
    });

    const formikEdit = useFormik({
        enableReinitialize: true,
        initialValues: {
            name: rname,
            surname: rsurname,
            number: rnumber,
            email: remail
        },
        onSubmit: value => {
            editItem(value);
        },
    });

    useEffect(() => {
        setItems(data);
    }, []);

    const deleteItem = (id) => {
        showLoad();
        const newItems = items.filter((item) => item.id !== id);
        setItems(newItems);
    };

    const addItem = (value) => {
        showLoad();
        items.push(
            {
                id: Date.now(),
                name: value.name,
                surname: value.surname,
                phoneNumber: value.number,
                email: value.email
            });

        setItems(items);
    };

    const editItem = (value) => {

        let item = items.find((item) => item.id == rid);

        item.id = rid;
        item.name = value.name;
        item.surname = value.surname;
        item.phoneNumber = value.number;
        item.email = value.email;

        setItems(items);
        showLoadLong();
    };

    async function showLoad() {
        setIsLoading(true);
        setTimeout(function () {
            setIsLoading(false);
        }, 250);
    };

    async function showLoadLong() {
        setIsLoading(true);
        setTimeout(function () {
            setIsLoading(false);
        }, 450);
    };

    return (
        <div className="p-4 p-md-5">
            <div className="container-full">
                <section className="content">
                    <div className="row">

                        <div className="col-8">
                            <div className="box">
                                <div className="box-header with-border">
                                    <h2 className="box-title">Administrators list</h2>
                                </div>
                                <div className="box-body">
                                    <div className="table table-responsive table-hover">
                                        <table id="example1" className="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Name</th>
                                                    <th>Surname</th>
                                                    <th>Mob. Number</th>
                                                    <th>Email</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {items?.map((administrators) =>

                                                    <tr>
                                                        <td>{administrators.name}</td>
                                                        <td>{administrators.surname}</td>
                                                        <td>{administrators.phoneNumber}</td>
                                                        <td>{administrators.email}</td>
                                                        {isLoading ?
                                                            <td>
                                                                <button className='btn btn-primary btn-group-justified disabled'>
                                                                    Edit
                                                                </button>
                                                                {
                                                                    administrators.email == loggedInAs ?
                                                                        <></>
                                                                        :
                                                                        <button className='btn btn-danger btn-group-justified disabled'>
                                                                            Remove
                                                                        </button>
                                                                }
                                                            </td>
                                                            :
                                                            <td>
                                                                <Modal
                                                                    size='small'
                                                                    open={open}
                                                                    onClose={() => setOpen(false)}
                                                                    onOpen={() => {
                                                                        setId(administrators.id);
                                                                        setName(administrators.name);
                                                                        setSurname(administrators.surname);
                                                                        setNumber(administrators.phoneNumber);
                                                                        setEmail(administrators.email);
                                                                        setOpen(true);
                                                                    }}
                                                                    trigger={
                                                                        <button className='btn btn-primary btn-group-justified'>
                                                                            Edit
                                                                        </button>}>
                                                                    <Modal.Content>
                                                                        <div>
                                                                            <div className="box-header with-border">
                                                                                <h3 className="box-title">Edit adinistrator</h3>
                                                                            </div>
                                                                            <div className="box-body">

                                                                                <form className="baseForm" onSubmit={formikEdit.handleSubmit}>
                                                                                    <div className="form-group">
                                                                                        <h5>Name</h5>
                                                                                        <div className="controls">
                                                                                            <input
                                                                                                className="inputField"
                                                                                                id="name"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.name}
                                                                                            />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div className="form-group">
                                                                                        <h5>Surname</h5>
                                                                                        <div className="controls">
                                                                                            <input
                                                                                                className="inputField"
                                                                                                id="surname"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.surname}
                                                                                            />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div className="form-group">
                                                                                        <h5>Mob. Number</h5>
                                                                                        <div className="controls">
                                                                                            <input
                                                                                                className="inputField"
                                                                                                id="number"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.number}
                                                                                            />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div className="form-group">
                                                                                        <h5>Email</h5>
                                                                                        <div className="controls">
                                                                                            <input
                                                                                                type='email'
                                                                                                className="inputField"
                                                                                                id="email"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.email}
                                                                                            />
                                                                                        </div>
                                                                                    </div>

                                                                                    {
                                                                                        remail == loggedInAs ?
                                                                                            <div className='pwWrapper'>
                                                                                                <div>
                                                                                                    <h4>Change password</h4>
                                                                                                </div>
                                                                                                <div className="form-group">
                                                                                                    <h5>Old password</h5>
                                                                                                    <div className="controls">
                                                                                                        <input
                                                                                                            type="password"
                                                                                                            className="inputField"
                                                                                                            id="oldpassword"
                                                                                                            onChange={formikEdit.handleChange}
                                                                                                        />
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div className="form-group">
                                                                                                    <h5>New password</h5>
                                                                                                    <div className="controls">
                                                                                                        <input
                                                                                                            type="password"
                                                                                                            className="inputField"
                                                                                                            id="newpassword"
                                                                                                            onChange={formikEdit.handleChange}
                                                                                                        />
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div className="form-group">
                                                                                                    <h5>Repeat new password</h5>
                                                                                                    <div className="controls">
                                                                                                        <input
                                                                                                            type="password"
                                                                                                            className="inputField"
                                                                                                            id="repeatnewpassword"
                                                                                                            onChange={formikEdit.handleChange}
                                                                                                        />
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            :
                                                                                            <></>
                                                                                    }

                                                                                    <button
                                                                                        className='btn btn-primary btn-group-justified btn-lg'
                                                                                        onClick={() => setOpen(false)}>
                                                                                        Cancel
                                                                                    </button>

                                                                                    <button
                                                                                        className='btn btn-success btn-group-justified btn-lg'
                                                                                        onClick={() => {
                                                                                            editItem(formikEdit.values);
                                                                                            setOpen(false);
                                                                                        }}>
                                                                                        Save
                                                                                    </button>
                                                                                </form>

                                                                            </div>
                                                                        </div>
                                                                    </Modal.Content>
                                                                </Modal>
                                                                {
                                                                    administrators.email == loggedInAs ?
                                                                        <></>
                                                                        :
                                                                        <button className='btn btn-danger btn-group-justified' onClick={() => deleteItem(administrators.id)}>
                                                                            Remove
                                                                        </button>
                                                                }
                                                            </td>
                                                        }
                                                    </tr>
                                                )}

                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="formWrapper col-4 box">
                            <div className="box-header with-border">
                                <h3 className="box-title">Create new adinistrator</h3>
                            </div>
                            <div className="box-body">

                                <form className="baseForm" onSubmit={formikCreate.handleSubmit}>
                                    <div className="form-group">
                                        <h5>Name<span className="text-danger">*</span></h5>
                                        <div className="controls">
                                            <input
                                                className="inputField"
                                                id="name"
                                                onChange={formikCreate.handleChange}
                                                value={formikCreate.values.name}
                                            />
                                        </div>
                                    </div>

                                    <div className="form-group">
                                        <h5>Surname<span className="text-danger">*</span></h5>
                                        <div className="controls">
                                            <input
                                                className="inputField"
                                                id="surname"
                                                onChange={formikCreate.handleChange}
                                                value={formikCreate.values.surname}
                                            />
                                        </div>
                                    </div>

                                    <div className="form-group">
                                        <h5>Mob. Number<span className="text-danger">*</span></h5>
                                        <div className="controls">
                                            <input
                                                type="tel"
                                                className="inputField"
                                                id="number"
                                                onChange={formikCreate.handleChange}
                                                value={formikCreate.values.number}
                                            />
                                        </div>
                                    </div>

                                    <div className="form-group">
                                        <h5>Email<span className="text-danger">*</span></h5>
                                        <div className="controls">
                                            <input
                                                type="email"
                                                className="inputField"
                                                id="email"
                                                onChange={formikCreate.handleChange}
                                                value={formikCreate.values.email}
                                            />
                                        </div>
                                    </div>

                                    <button className='btn btn-primary btn-group-justified btn-lg'>
                                        Add
                                    </button>
                                </form>

                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    );
};
export default AdminAdministrator;