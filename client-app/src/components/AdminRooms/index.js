import React, { useEffect, useState } from 'react';
import { useFormik } from 'formik';
import data from '../../store/Data/rooms.json';
import Table from 'react-bootstrap/Table';
import './style.scss';
import { Modal } from 'semantic-ui-react';

function AdminRoom() {

    const [items, setItems] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [open, setOpen] = useState(false)

    const [rid, setId] = useState("");
    const [rtype, setType] = useState("");
    const [rnumber, setNumber] = useState("");

    const formik = useFormik({
        initialValues: {
            type: "BasicForTwo",
            number: ""
        },
        onSubmit: value => {
            addItem(value);
        },
    });

    const formikEdit = useFormik({
        enableReinitialize: true,
        initialValues: {
            type: rtype,
            number: rnumber,
        },
        onSubmit: value => {
            editItem(value);
        },
    });

    useEffect(() => {
        setItems(data);
    }, []);

    const addItem = (value) => {
        showLoad();
        items.push(
            {
                id: Date.now(),
                type: value.type,
                number: value.number,
                reservationsIds: []
            });
        setItems(items);
    };

    const editItem = (value) => {
        let item = items.find((item) => item.id == rid);

        item.id = rid;
        item.type = value.type;
        item.number = value.number;

        setTimeout(function () {
            setItems(items);
        }, 250);
    };

    const deleteItem = (id) => {
        showLoad();
        const newItems = items.filter((item) => item.id !== id);
        setItems(newItems);
    };

    async function showLoad() {
        setIsLoading(true);
        setTimeout(function () {
            setIsLoading(false);
        }, 250);
    };

    const typeOptions = [
        { key: 'bft', value: 'BasicForTwo' },
        { key: 'mft', value: 'MiniForTwo' },
        { key: 'vft', value: 'VipForTwo' },
        { key: 'vffa', value: 'VipForFamily' },
        { key: 'vffr', value: 'VipForFriends' }
    ]

    return (
        <div className="p-4 p-md-5">
            <div className="container-full">
                <section className="content">
                    <div className="row">

                        <div className="col-8">
                            <div className="box">
                                <div className="box-header with-border">
                                    <h2 className="box-title">Rooms list</h2>
                                </div>
                                <div className="box-body">
                                    <div className="table-responsive">
                                        <Table responsive bordered hover>
                                            <thead>
                                                <tr>
                                                    <th>Photo</th>
                                                    <th>Type</th>
                                                    <th>Number</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {items?.map((room) =>

                                                    <tr>
                                                        <td>
                                                            <img src={`/images/` + room.type + `.png`} alt="RoomForTwo" className='image' />
                                                        </td>
                                                        <td>{room.type}</td>
                                                        <td>{room.number}</td>
                                                        {isLoading ?
                                                            <td>
                                                                <button className='btn btn-primary btn-group-justified disabled'>
                                                                    Edit
                                                                </button>
                                                                <button className='btn btn-danger btn-group-justified disabled' id="delete">
                                                                    Remove
                                                                </button>
                                                            </td>
                                                            :
                                                            <td>
                                                                <Modal
                                                                    size='mini'
                                                                    open={open}
                                                                    onClose={() => setOpen(false)}
                                                                    onOpen={() => {
                                                                        setId(room.id);
                                                                        setType(room.type);
                                                                        setNumber(room.number);
                                                                        setOpen(true);
                                                                    }}
                                                                    trigger={
                                                                        <button className='btn btn-primary btn-group-justified'>
                                                                            Edit
                                                                        </button>}>
                                                                    <Modal.Content>
                                                                        <div>
                                                                            <div className="box-header with-border">
                                                                                <h3 className="box-title">Edit room</h3>
                                                                            </div>
                                                                            <div className="box-body">

                                                                                <form className="baseForm" onSubmit={formikEdit.handleSubmit}>
                                                                                    <div className="form-group">
                                                                                        <h5>Room Type</h5>
                                                                                        <div className="controls">
                                                                                            <select
                                                                                                className="inputField"
                                                                                                id="type"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.type}
                                                                                            >
                                                                                                {
                                                                                                    typeOptions.map((option) =>
                                                                                                        <option key={option.key}>{option.value}</option>
                                                                                                    )
                                                                                                }
                                                                                            </select>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div className="form-group">
                                                                                        <h5>Room number</h5>
                                                                                        <div className="controls">
                                                                                            <input
                                                                                                type="number"
                                                                                                className="inputField"
                                                                                                id="number"
                                                                                                onChange={formikEdit.handleChange}
                                                                                                value={formikEdit.values.number}
                                                                                            />
                                                                                        </div>
                                                                                    </div>

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
                                                                <button className='btn btn-danger btn-group-justified' id="delete" onClick={() => deleteItem(room.id)}>
                                                                    Remove
                                                                </button>
                                                            </td>
                                                        }
                                                    </tr>

                                                )}
                                            </tbody>
                                        </Table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-4">
                            <div className="formWrapper">
                                <div className="box">
                                    <div className="box-header with-border">
                                        <h3 className="box-title">Add room </h3>
                                    </div>
                                    <div className="box-body">
                                        <div className="table-responsive">
                                            <form className="baseForm" onSubmit={formik.handleSubmit}>


                                                <div className="form-group">
                                                    <h5>Type<span className="text-danger">*</span></h5>
                                                    <div className="controls">
                                                        <select
                                                            className="inputField"
                                                            id="type"
                                                            onChange={formik.handleChange}
                                                            value={formik.values.type}
                                                        >
                                                            {
                                                                typeOptions.map((option) =>
                                                                    <option key={option.key}>{option.value}</option>
                                                                )
                                                            }
                                                        </select>
                                                    </div>
                                                </div>
                                                <div className="form-group">
                                                    <h5>Number<span className="text-danger">*</span></h5>
                                                    <div className="controls">
                                                        <input
                                                            type="number"
                                                            className="inputField"
                                                            id="number"
                                                            onChange={formik.handleChange}
                                                            value={formik.values.number}
                                                        />
                                                    </div>
                                                </div>
                                                <button className='btn btn-primary btn-group-justified' type="submit">
                                                    Add
                                                </button>

                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    );
};
export default AdminRoom;