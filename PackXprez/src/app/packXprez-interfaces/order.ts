export interface IOrder {
  ShipmentType: number;
  EmailId: string,
  PackageLength: number,
  PackageBreadth: number,
  PackageHeight: number,
  PackageWeight: number,
  PackagingRequired: string,
  DeliveryType: string,
  PickUpTime: string,
  SenderAddressId: number
}
